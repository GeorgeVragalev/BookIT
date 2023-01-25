using Backend.Entities.LessonEntities;
using Backend.Entities.Shared;
using Backend.Entities.UniversityEntities;

namespace Backend.Models;

public class TimePeriodModel: BaseEntity
{
    public int Id { get; set; }
    public WeekDayType WeekDay { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public IList<LessonModel>? Lessons { get; set; }
}