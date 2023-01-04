using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class ForgotPasswordModel
{
    [Microsoft.Build.Framework.Required]
    [EmailAddress]
    public string Email { get; set; }
}