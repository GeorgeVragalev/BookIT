using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
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
    
    public int? TeacherId { get; set; }
    public virtual Teacher? Teacher { get; set; }
    
    public int? StudentId { get; set; }
    public virtual Student? Student { get; set; }
}