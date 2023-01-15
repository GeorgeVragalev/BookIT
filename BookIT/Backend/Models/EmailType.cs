using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public enum EmailType
{
    [Display(Name = "Reset your password")]
    ResetPassword,
    [Display(Name = "Confirm your email")]
    ConfirmEmail
}