using Backend.Entities.Shared;

namespace Backend.Models;

public class GroupModel : IBaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual IList<StudentModel>? Students { get; set; }
}