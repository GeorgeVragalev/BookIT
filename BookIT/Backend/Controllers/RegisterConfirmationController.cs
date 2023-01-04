using System.Text;
using Backend.Entities.Users;
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
            var userId = await _userManager.GetUserIdAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            model.EmailConfirmationUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new {area = "Identity", userId = userId, code = code, returnUrl = returnUrl},
                protocol: Request.Scheme);
        }

        return View(model);
    }
}