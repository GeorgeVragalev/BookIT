using MimeKit;

namespace Backend.Models;

public class Message
{
    public MailboxAddress Receiver { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }

    public Message(string receiver, string subject, string content)
    {
        Receiver = new MailboxAddress("BookIT", receiver);
        Subject = subject;
        Content = content;
    }
}