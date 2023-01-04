using Backend.Entities.Users;
using Backend.Helpers;
using Backend.Models;
using Backend.Services.EmailService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

public class ForgotPasswordController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly IEmailService _emailService;
    private const string EmailSubject = "Reset password";

    public ForgotPasswordController(UserManager<User> userManager, IEmailService emailService)
    {
        _userManager = userManager;
        _emailService = emailService;
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
                var callbackUrl = await UrlHelper.PrepareCallbackUrl(user, _userManager, Url, Request);

                SendResetPasswordEmail(model.Email, callbackUrl);
                return View("ForgotPasswordConfirmation");
            }

            return View("ForgotPasswordConfirmation");
        }

        return View(model);
    }

    private void SendResetPasswordEmail(string receiver, string callbackUrl)
    {
        var bodyMessage = MessageHelper.PrepareMessage(callbackUrl);
        var message = new Message(receiver, EmailSubject, bodyMessage);
        _emailService.SendEmail(message);
    }
}