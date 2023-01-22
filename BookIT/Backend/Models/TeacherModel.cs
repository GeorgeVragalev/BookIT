using Backend.Entities.Shared;

namespace Backend.Models;

public class TeacherModel : IBaseEntity
{
    public int Id { get; set; }
    public string? AboutMe { get; set; }
    public string? Quote { get; set; }

    public virtual DepartmentModel Department { get; set; }
    public virtual UserModel User { get; set; }
    public virtual IList<SubjectModel>? Subjects { get; set; }
}