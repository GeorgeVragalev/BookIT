using System.ComponentModel.DataAnnotations;
using Backend.Entities.Roles;

namespace Backend.Models;

public class UserModel
{
    [RegularExpression(@"^[a-zA-Z''-'\s@.]{1,40}$", 
        ErrorMessage = "Characters are not allowed.")]
    public string Email { get; set; }
    public string Password { get; set; }
    public RoleEnum Role { get; set; }
}