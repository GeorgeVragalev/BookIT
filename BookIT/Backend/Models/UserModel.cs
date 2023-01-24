using System.ComponentModel.DataAnnotations;
using Backend.Entities.Roles;
using Backend.Entities.Shared;

namespace Backend.Models;

public class UserModel: IBaseEntity
{
    public int Id { get; set; }
    
    [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", 
        ErrorMessage = "Characters are not allowed.")]
    public string Email { get; set; }
    
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public RoleEnum Role { get; set; }
    public StudentModel? Student{ get; set; }
    public TeacherModel? Teacher{ get; set; }
}