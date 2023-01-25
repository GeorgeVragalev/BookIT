using Backend.Entities.LessonEntities;
using Backend.Entities.Shared;

namespace Backend.Entities.UniversityEntities;

public class TimePeriod : BaseEntity
{
    public int Id { get; set; }
    public WeekDayType WeekDay { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public virtual IList<Lesson>? Lessons { get; set; }
}