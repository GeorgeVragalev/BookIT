
namespace Backend.Services.ReCaptcha;

public interface IReCaptchaService
{
    Task<bool> IsValid(string inputToken);
}