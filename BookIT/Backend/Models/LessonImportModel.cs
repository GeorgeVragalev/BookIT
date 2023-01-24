using Backend.Entities.LessonEntities;
using Backend.Entities.UniversityEntities;

namespace Backend.Models;

public class LessonImportModel
{
    public string? Name { get; set; }
    public LessonType LessonType { get; set; }
    public WeekType WeekType { get; set; }
    public WeekDayType WeekDay { get; set; }

    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public string? RoomName { get; set; }
    public string? TeacherEmail { get; set; }
    public string? Group { get; set; }
    public string? Subject { get; set; }
    public int NumberOfLessons{ get; set; }
    public int WeeklySeparation{ get; set; }
}