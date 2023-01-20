using Backend.Models.Recaptcha;
using Newtonsoft.Json;

namespace Backend.Services.ReCaptcha;

public class ReCaptchaService : IReCaptchaService
{
    public virtual async Task<ReCaptchaResponse?> TokenVerify(string token)
    {
        var data = new ReCaptchaData
        {
            Response = token,
            Secret = ReCaptchaCredentials.SecretKey
        };

        var client = new HttpClient();
        var response =
            await client.GetStringAsync(
                $"https://www.google.com/recaptcha/api/siteverify?secret={data.Secret}&response={data.Response}");
        return JsonConvert.DeserializeObject<ReCaptchaResponse>(response);
    }
}