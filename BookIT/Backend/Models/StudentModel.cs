using Backend.Entities.Shared;

namespace Backend.Models;

public class StudentModel : IBaseEntity
{
    public int Id { get; set; }
    public string? AboutMe { get; set; }
    public virtual UserModel? User { get; set; }
    public virtual GroupModel? Group { get; set; }
}