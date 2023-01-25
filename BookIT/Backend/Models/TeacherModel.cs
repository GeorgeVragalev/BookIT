using Backend.Entities.Shared;

namespace Backend.Models;

public class TeacherModel : BaseEntity
{
    public int Id { get; set; }
    public string? AboutMe { get; set; }
    public string? Quote { get; set; }

    public virtual DepartmentModel? Department { get; set; }
    public virtual UserModel? User { get; set; }
    public virtual List<SubjectModel>? Subjects { get; set; }
    public IList<LessonModel>? Lessons { get; set; }
}