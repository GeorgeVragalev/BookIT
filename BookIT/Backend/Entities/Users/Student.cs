using Backend.Entities.Shared;
using Backend.Entities.UniversityEntities;

namespace Backend.Entities.Users;

public class Student : IBaseEntity
{
    public int Id { get; set; }
    public string? AboutMe { get; set; }
    
    public int UserId { get; set; }
    public virtual User User { get; set; }

    public int GroupId { get; set; }
    public virtual Group Group { get; set; }
}