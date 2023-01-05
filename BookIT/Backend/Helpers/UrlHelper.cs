using System.Security.Policy;
using System.Text;
using Backend.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace Backend.Helpers;

public static class UrlHelper
{
    public static string PrepareCallbackUrl(IUrlHelper urlHelper, HttpRequest httpRequest, string code, string pageName, int userId)
    {
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        var callbackUrl = urlHelper.Page(
            pageName,
            pageHandler: null,
            values: new {area = "Identity", userId = userId, code = code, returnUrl = urlHelper.Content("~/")},
            protocol: httpRequest.Scheme);

        return callbackUrl ?? "";
    }
}