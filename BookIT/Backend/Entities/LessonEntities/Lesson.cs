using Backend.Entities.Rooms;
using Backend.Entities.Shared;
using Backend.Entities.UniversityEntities;
using Backend.Entities.Users;

namespace Backend.Entities.LessonEntities;

public class Lesson : IBaseEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public LessonType LessonType { get; set; }
    public WeekType WeekType { get; set; }

    public int TimePeriodId { get; set; }
    public virtual TimePeriod TimePeriod { get; set; }

    public int? RoomId { get; set; }
    public virtual Room? Room { get; set; }

    public int? TeacherId { get; set; }
    public virtual Teacher? Teacher { get; set; }

    public int? GroupId { get; set; }
    public virtual Group? Group { get; set; }

    public int? SubjectId { get; set; }
    public virtual Subject? Subject { get; set; }

    public string GetLessonLocation()
    {
        if (LessonType != LessonType.Class)
        {
            return LessonType.ToString();
        }

        
        return Room?.Name ?? LessonType.ToString();
    }
}