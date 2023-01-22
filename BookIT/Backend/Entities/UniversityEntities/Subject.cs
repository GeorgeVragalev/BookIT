using Backend.Entities.Shared;
using Backend.Entities.Users;

namespace Backend.Entities.UniversityEntities;

public class Subject : IBaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? Laboratories { get; set; }
    public int? Exams { get; set; }
    public int? Hours { get; set; }
    
    public virtual IList<TeacherSubject>? TeacherSubjects { get; set; }
}