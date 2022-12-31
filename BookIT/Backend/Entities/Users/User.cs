using System.Diagnostics.CodeAnalysis;
using Backend.Entities.Shared;
using Microsoft.AspNetCore.Identity;

namespace Backend.Entities.Users;

public class User : IdentityUser<int>, IBaseEntity
{
    [AllowNull]
    public string FirstName { get; set; }
    [AllowNull]
    public string LastName { get; set; }
}