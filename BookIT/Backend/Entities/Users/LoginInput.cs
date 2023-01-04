using System.ComponentModel.DataAnnotations;

namespace Backend.Entities.Users;

public class LoginInput
{
    [Microsoft.Build.Framework.Required]
    [EmailAddress]
    public string Email { get; set; }

    [Microsoft.Build.Framework.Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    /// </summary>
    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }
}