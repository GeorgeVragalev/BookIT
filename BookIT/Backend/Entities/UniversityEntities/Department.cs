using Backend.Entities.Shared;
using Backend.Entities.Users;

namespace Backend.Entities.UniversityEntities;

public class Department : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual IList<Teacher>? Teachers { get; set; }
}