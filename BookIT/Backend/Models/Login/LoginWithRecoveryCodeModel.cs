using Backend.Entities.Login;
using Backend.Entities.Users;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Models.Login;

public class LoginWithRecoveryCodeModel
{
    [BindProperty]
    public LoginWithRecoveryCodeInput Input { get; set; }

    /// <summary>
    ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
    ///     directly from your code. This API may change or be removed in future releases.
    /// </summary>
    public string ReturnUrl { get; set; }
}