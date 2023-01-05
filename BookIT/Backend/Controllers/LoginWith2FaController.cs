using Backend.Entities.Users;
using Backend.Models.Login;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

public class LoginWith2FaController : Controller
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;

    public LoginWith2FaController(
        SignInManager<User> signInManager,
        UserManager<User> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }   
    
    [HttpGet]
    public async Task<IActionResult> LoginWith2Fa(bool rememberMe, string returnUrl = null)
    {
        var model = new LoginWith2Fa();
        
        // Ensure the user has gone through the username & password screen first
        var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();

        if (user == null)
        {
            throw new InvalidOperationException($"Unable to load two-factor authentication user.");
        }

        model.ReturnUrl = returnUrl;
        model.RememberMe = rememberMe;

        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> LoginWith2FaPost(bool rememberMe, string returnUrl = null)
    {
        var model = new LoginWith2Fa();
        
        if (!ModelState.IsValid)
        {
            return View("LoginWith2Fa", model);
        }

        returnUrl = returnUrl ?? Url.Content("~/");

        var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
        if (user == null)
        {
            throw new InvalidOperationException($"Unable to load two-factor authentication user.");
        }

        var authenticatorCode = model.Input.TwoFactorCode.Replace(" ", string.Empty).Replace("-", string.Empty);

        var result = await _signInManager.TwoFactorAuthenticatorSignInAsync(authenticatorCode, rememberMe, model.Input.RememberMachine);

        var userId = await _userManager.GetUserIdAsync(user);

        if (result.Succeeded)
        {
            return LocalRedirect(returnUrl);
        }
        else if (result.IsLockedOut)
        {
            return RedirectToPage("./Lockout");
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Invalid authenticator code.");
            
            return View("LoginWith2Fa", model);
        }
    }
}