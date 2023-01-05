using Backend.Entities.Roles;

namespace Backend.Models;

public class UserModel
{
    public string Email { get; set; }
    public RoleEnum Role { get; set; }
}