using System.ComponentModel.DataAnnotations;
using Backend.Entities.Roles;
using Backend.Entities.Shared;

namespace Backend.Models;

public class UserModel: IBaseEntity
{
    public int Id { get; set; }
    
    [RegularExpression(@"^[a-zA-Z''-'\s@.]{1,40}$", 
        ErrorMessage = "Characters are not allowed.")]
    public string Email { get; set; }
    public RoleEnum Role { get; set; }
    public StudentModel? StudentModel{ get; set; }
    public TeacherModel? TeacherModel{ get; set; }
}