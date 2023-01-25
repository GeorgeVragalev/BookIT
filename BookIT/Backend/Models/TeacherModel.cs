using System.Text.Json.Serialization;
using Backend.Entities.Shared;

namespace Backend.Models;

public class TeacherModel : IBaseEntity
{
    public int Id { get; set; }
    public string? AboutMe { get; set; }
    public string? Quote { get; set; }

    public virtual DepartmentModel? Department { get; set; }
    public virtual UserModel? User { get; set; }
    public virtual List<SubjectModel>? Subjects { get; set; }
    public virtual IList<LessonModel>? Lessons { get; set; }
}