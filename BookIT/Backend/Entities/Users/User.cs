using System.ComponentModel.DataAnnotations;
using Backend.Entities.Shared;
using Microsoft.AspNetCore.Identity;

namespace Backend.Entities.Users;

public class User : IdentityUser<int>, IBaseEntity
{
    //TODO: Remove nullable
    [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", 
        ErrorMessage = "Characters are not allowed.")]
    public string? FirstName { get; set; }
    [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", 
        ErrorMessage = "Characters are not allowed.")]
    public string? LastName { get; set; }
}