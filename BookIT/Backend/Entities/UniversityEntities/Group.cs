using Backend.Entities.LessonEntities;
using Backend.Entities.Shared;
using Backend.Entities.Users;

namespace Backend.Entities.UniversityEntities;

public class Group : IBaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual IList<Student>? Students { get; set; }
    public virtual IList<Lesson>? Lessons { get; set; }
}