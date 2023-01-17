using System.Text.Encodings.Web;
using Backend.Entities.Users;
using Backend.Helpers;
using Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[AutoValidateAntiforgeryToken]
public class ForgotPasswordController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly IEmailSender _emailSender;

    public ForgotPasswordController(UserManager<User> userManager, IEmailSender emailSender)
    {
        _userManager = userManager;
        _emailSender = emailSender;
    }

    [HttpGet]
    public IActionResult ForgotPassword()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null && await _userManager.IsEmailConfirmedAsync(user))
            {
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = UrlHelper.PrepareCallbackUrl(Url, Request, code,"/Account/ResetPassword", user.Id);

                SendResetPasswordEmail(model.Email, callbackUrl);
                return View("ForgotPasswordConfirmation");
            }

            return View("ForgotPasswordConfirmation");
        }

        return View(model);
    }

    private void SendResetPasswordEmail(string receiver, string callbackUrl)
    {
        var bodyMessage = PrepareMessage(callbackUrl);
        _emailSender.SendEmailAsync(receiver, "Reset password", bodyMessage);
    }

    private static string PrepareMessage(string callbackUrl)
    {
        return $"Please reset your password by <a href=\"{HtmlEncoder.Default.Encode(callbackUrl)}\">clicking here</a>.";
    }
}