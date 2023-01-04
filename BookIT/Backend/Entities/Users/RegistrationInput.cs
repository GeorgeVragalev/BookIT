using System.ComponentModel.DataAnnotations;

namespace Backend.Entities.Users;

public class RegistrationInput
{
    [Microsoft.Build.Framework.Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Microsoft.Build.Framework.Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
        MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
}