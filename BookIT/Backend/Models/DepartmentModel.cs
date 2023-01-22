using Backend.Entities.Shared;

namespace Backend.Models;

public class DepartmentModel : IBaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual List<TeacherModel>? Teachers { get; set; }
}