using System.Text;
using Backend.Entities.Users;
using Backend.Helpers;
using Backend.Models.Register;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace Backend.Controllers;

public class RegisterConfirmationController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly IEmailSender _sender;

    public RegisterConfirmationController(UserManager<User> userManager, IEmailSender sender)
    {
        _userManager = userManager;
        _sender = sender;
    }

    public async Task<IActionResult> RegisterConfirmation(string email, string returnUrl = null)
    {
        var model = new RegisterConfirmationModel();
        if (email == null)
        {
            return RedirectToPage("/Index");
        }

        returnUrl = returnUrl ?? Url.Content("~/");

        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
        {
            return NotFound($"Unable to load user with email '{email}'.");
        }

        model.Email = email;
        // Once you add a real email sender, you should remove this code that lets you confirm the account
        model.DisplayConfirmAccountLink = true;
        if (model.DisplayConfirmAccountLink)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = UrlHelper.PrepareCallbackUrl(Url, Request, code,"/Account/ConfirmEmail", user.Id);
        }

        return View(model);
    }
}