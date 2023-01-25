using Backend.Entities.Shared;

namespace Backend.Models;

public class StudentModel : BaseEntity
{
    public int Id { get; set; }
    public string? AboutMe { get; set; }
    public virtual UserModel? User { get; set; }
    public virtual GroupModel? Group { get; set; }
}