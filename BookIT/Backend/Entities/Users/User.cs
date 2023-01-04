using Backend.Entities.Shared;
using Microsoft.AspNetCore.Identity;

namespace Backend.Entities.Users;

public class User : IdentityUser<int>, IBaseEntity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}