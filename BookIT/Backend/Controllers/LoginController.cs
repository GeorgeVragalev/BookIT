using Backend.Entities.Users;
using Backend.Models.Login;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

public class LoginController : Controller
{
    private readonly SignInManager<User> _signInManager;

    public LoginController(SignInManager<User> signInManager)
    {
        _signInManager = signInManager;
    }

    [HttpGet]
    public async Task<ViewResult> Login(string returnUrl = null)
    {
        var model = new LoginModel();
        if (!string.IsNullOrEmpty(model.ErrorMessage))
        {
            ModelState.AddModelError(string.Empty, model.ErrorMessage);
        }

        returnUrl ??= Url.Content("~/");

        // Clear the existing external cookie to ensure a clean login process
        await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
        
        model.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

        model.ReturnUrl = returnUrl;

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Login(string email, string password, bool rememberMe, string returnUrl = null)
    {
        var model = new LoginModel();
        returnUrl ??= Url.Content("~/");

        model.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

        // if (ModelState.IsValid)
        // {
            var result = await _signInManager.PasswordSignInAsync(email, password, rememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return LocalRedirect(returnUrl);
            }

            if (result.RequiresTwoFactor)
            {
                return RedirectToPage("./LoginWith2fa", new {ReturnUrl = returnUrl, RememberMe = rememberMe});
            }

            if (result.IsLockedOut)
            {
                return RedirectToPage("./Lockout");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(model);
        // }

        // If we got this far, something failed, redisplay form
        return View();
    }
}