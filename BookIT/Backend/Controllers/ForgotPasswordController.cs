using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.Encodings.Web;
using Backend.Entities.Users;
using Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace Backend.Controllers;

public class ForgotPasswordController : Controller
{
    private UserManager<User> _userManager { set; get; }

    public ForgotPasswordController(UserManager<User> userManager)
    {
        _userManager = userManager;
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
                var callbackUrl = await PrepareCallbackUrl(user);
                SendResetPasswordEmail(model.Email, callbackUrl);
                return View("ForgotPasswordConfirmation");
            }

            return View("ForgotPasswordConfirmation");
        }

        return View(model);
    }

    private async Task<string> PrepareCallbackUrl(User user)
    {
        var code = await _userManager.GeneratePasswordResetTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        var callbackUrl = Url.Page(
            "/Account/ResetPassword",
            pageHandler: null,
            values: new {area = "Identity", code},
            protocol: Request.Scheme);

        return callbackUrl ?? "";
    }

    private void SendResetPasswordEmail(string receiver, string callbackUrl)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var senderEmail = new MailAddress("bookit2024@gmail.com", "BookIT");
                var receiverEmail = new MailAddress(receiver, "Receiver");
                const string password = "c_GxfNK3:emRSgs";
                const string subject = "Reset Password";
                var body =
                    $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.";
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderEmail.Address, password),
                    EnableSsl = true
                };
                using var mess = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = subject,
                    Body = body
                };
                smtp.Send(mess);
            }
        }
        catch (Exception)
        {
            ViewBag.Error = "Some Error";
        }
    }
}