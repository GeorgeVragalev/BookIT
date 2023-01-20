using System.Text;
using Backend.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace Backend.Helpers;

public static class UrlHelper
{
    public static async Task<string> PrepareCallbackUrl(User user, UserManager<User> userManager, IUrlHelper urlHelper,
        HttpRequest httpRequest)
    {
        var code = await userManager.GeneratePasswordResetTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        var callbackUrl = urlHelper.Page(
            "/Account/ResetPassword",
            pageHandler: null,
            values: new {area = "Identity", code},
            protocol: httpRequest.Scheme);

        return callbackUrl ?? "";
    }
}