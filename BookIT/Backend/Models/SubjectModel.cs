using Backend.Entities.Shared;
using Backend.Entities.Users;

namespace Backend.Models;

public class SubjectModel : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? Laboratories { get; set; }
    public int? Exams { get; set; }
    public int? Hours { get; set; }
    
    public virtual List<TeacherModel>? Teachers { get; set; }
    public IList<LessonModel>? Lessons { get; set; }
}