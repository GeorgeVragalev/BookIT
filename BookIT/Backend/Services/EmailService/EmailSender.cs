using Backend.Helpers;
using Backend.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;

namespace Backend.Services.EmailService;

public class EmailSender : IEmailSender
{
    private readonly EmailConfiguration _emailConfig;

    public EmailSender(EmailConfiguration emailConfig)
    {
        _emailConfig = emailConfig;
    }

    public void SendEmail(string email, string subject, string htmlMessage)
    {
        var emailMessage = MessageHelper.PrepareEmailMessage(email, _emailConfig.From, subject, htmlMessage);
        Execute(emailMessage);
    }

    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var emailMessage = MessageHelper.PrepareEmailMessage(email, _emailConfig.From, subject, htmlMessage);
        Execute(emailMessage);
        return Task.CompletedTask;
    }

    private void Execute(MimeMessage mailMessage)
    {
        using var client = new SmtpClient();
        try
        {
            client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            client.Authenticate(_emailConfig.UserName, _emailConfig.Password);
            client.Send(mailMessage);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Failed to send email! Exception: {e}");
        }
        finally
        {
            client.Disconnect(true);
            client.Dispose();
        }
    }
}