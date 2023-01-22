using Backend.Entities.Users;

namespace Backend.Entities.UniversityEntities;

public class TeacherSubject
{
    public int TeacherId { get; set; }
    public virtual Teacher Teacher { get; set; }

    public int SubjectId { get; set; }
    public virtual Subject Subject { get; set; }
}