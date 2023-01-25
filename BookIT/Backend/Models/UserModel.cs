using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Backend.Entities.Roles;
using Backend.Entities.Shared;

namespace Backend.Models;

public class UserModel: IBaseEntity
{
    public int Id { get; set; }
    
    [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", 
        ErrorMessage = "Please enter a valid email format")]
    public string Email { get; set; }
    
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public RoleEnum Role { get; set; }
    [JsonIgnore]
    public StudentModel? Student{ get; set; }
    [JsonIgnore]
    public TeacherModel? Teacher{ get; set; }
}