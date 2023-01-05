using Backend.Entities.Users;
using Backend.Models.Login;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

public class LoginWithRecoveryCodeController : Controller
{
    private readonly SignInManager<User> _signInManager;

    public LoginWithRecoveryCodeController(SignInManager<User> signInManager)
    {
        _signInManager = signInManager;
    }

    [HttpGet]
    public async Task<IActionResult> LoginWithRecoveryCode(string returnUrl = null)
    {
        var model = new LoginWithRecoveryCodeModel();
        // Ensure the user has gone through the username & password screen first
        var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
        if (user == null)
        {
            throw new InvalidOperationException($"Unable to load two-factor authentication user.");
        }

        model.ReturnUrl = returnUrl;

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> LoginWithRecoveryCodePost(string? returnUrl = null)
    {
        var model = new LoginWithRecoveryCodeModel();
        if (!ModelState.IsValid)
        {
            return View("LoginWithRecoveryCode", model);
        }

        var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
        if (user == null)
        {
            throw new InvalidOperationException($"Unable to load two-factor authentication user.");
        }

        var recoveryCode = model.Input.RecoveryCode.Replace(" ", string.Empty);

        var result = await _signInManager.TwoFactorRecoveryCodeSignInAsync(recoveryCode);

        if (result.Succeeded)
        {
            return LocalRedirect(returnUrl ?? Url.Content("~/"));
        }

        if (result.IsLockedOut)
        {
            return RedirectToPage("./Lockout");
        }

        ModelState.AddModelError(string.Empty, "Invalid recovery code entered.");
        return View("LoginWithRecoveryCode", model);
    }
}