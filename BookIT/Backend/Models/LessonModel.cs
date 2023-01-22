using Backend.Entities.LessonEntities;

namespace Backend.Models;

public class LessonModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public LessonType LessonType { get; set; }
    public WeekType WeekType { get; set; }

    public virtual TimePeriodModel TimePeriod { get; set; }
    public virtual RoomModel? Room { get; set; }
    public virtual TeacherModel? Teacher { get; set; }
    public virtual GroupModel? Group { get; set; }
    public virtual SubjectModel? Subject { get; set; }
}