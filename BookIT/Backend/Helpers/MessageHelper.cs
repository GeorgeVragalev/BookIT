using MimeKit;
using MimeKit.Cryptography;

namespace Backend.Helpers;

public static class MessageHelper
{
    public static MimeMessage PrepareEmailMessage(string emailTo, string emailFrom, string subject, string htmlMessage)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress("emailFrom", emailFrom));
        emailMessage.To.Add(new MailboxAddress("emailTo", emailTo));
        emailMessage.Subject = subject;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) {Text = htmlMessage};
        return emailMessage;
    }
}