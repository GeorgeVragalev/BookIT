using Backend.Models.Recaptcha;

namespace Backend.Services.ReCaptcha;

public interface IReCaptchaService
{
    Task<ReCaptchaResponse?> TokenVerify(string token);
}