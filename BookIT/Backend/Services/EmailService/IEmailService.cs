using Backend.Models;

namespace Backend.Services.EmailService;

public interface IEmailService
{
    void SendEmail(Message message);
}