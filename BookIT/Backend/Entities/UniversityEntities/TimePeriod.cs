using Backend.Entities.Shared;

namespace Backend.Entities.UniversityEntities;

public class TimePeriod : IBaseEntity
{
    public int Id { get; set; }
    public WeekDayType WeekDay { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}