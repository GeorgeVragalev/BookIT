using Backend.Models;

namespace Backend.Services.EmailService;

public interface IEmailService
{
    public void SendEmail(Message message);
}