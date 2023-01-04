using Backend.Entities.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Models.Register;

public class RegisterModel
{
    [BindProperty]
    public RegistrationInput Input { get; set; }
    public string ReturnUrl { get; set; }
    public IList<AuthenticationScheme> ExternalLogins { get; set; }
}