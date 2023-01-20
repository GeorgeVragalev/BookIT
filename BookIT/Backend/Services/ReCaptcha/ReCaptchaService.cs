using Backend.Models.Recaptcha;
using Newtonsoft.Json;

namespace Backend.Services.ReCaptcha;

public class ReCaptchaService : IReCaptchaService
{
    private async Task<ReCaptchaResponse?> TokenVerify(string token)
    {
        var data = new ReCaptchaData
        {
            Response = token,
            Secret = "6LdtNhQkAAAAABhEOv5-ISfvn4SyaknIxZXadNWb"
        };

        var client = new HttpClient();
        var response =
            await client.GetStringAsync(
                $"https://www.google.com/recaptcha/api/siteverify?secret={data.Secret}&response={data.Response}");
        return JsonConvert.DeserializeObject<ReCaptchaResponse>(response);
    }

    public async Task<bool> IsValid(string token)
    {
        var reCaptchaResult = await TokenVerify(token);
        return reCaptchaResult!.Success && reCaptchaResult.Score >= 0.5;
    }
}