using System.Text.Encodings.Web;

namespace Backend.Helpers;

public static class MessageHelper
{
    public static string PrepareMessage(string callbackUrl)
    {
        return $"Please reset your password by <a href=\"{HtmlEncoder.Default.Encode(callbackUrl)}\">clicking here</a>.";
    }
}