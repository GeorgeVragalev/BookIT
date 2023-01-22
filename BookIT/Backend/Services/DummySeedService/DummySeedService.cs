using Backend.Entities.LessonEntities;
using Backend.Entities.Rooms;
using Backend.Entities.UniversityEntities;
using Backend.Services.Rooms.RoomService;
using Backend.Services.University.DepartmentService;
using Backend.Services.University.GroupService;
using Backend.Services.University.LessonService;
using Backend.Services.University.SubjectService;
using Backend.Services.Users.TeacherService;

namespace Backend.Services.DummySeedService;

public class DummySeedService : IDummySeedService
{
    private readonly IGroupService _groupService;
    private readonly IDepartmentService _departmentService;
    private readonly ISubjectService _subjectService;
    private readonly ITeacherService _teacherService;
    private readonly ILessonService _lessonService;
    private readonly ITimePeriodService _timePeriodService;
    private readonly IRoomService _roomService;

    public DummySeedService(IGroupService groupService, IDepartmentService departmentService, ISubjectService subjectService, ILessonService lessonService, ITeacherService teacherService, ITimePeriodService timePeriodService, IRoomService roomService)
    {
        _groupService = groupService;
        _departmentService = departmentService;
        _subjectService = subjectService;
        _lessonService = lessonService;
        _teacherService = teacherService;
        _timePeriodService = timePeriodService;
        _roomService = roomService;
    }

    public async Task SeedDb()
    {
        var faf203 = new Group()
        {
            Name = "FAF-203"
        };

        var fcim = new Department()
        {
            Name = "FCIM"
        };

        var tmps = new Subject()
        {
            Name = "TMPS",
            Exams = 2,
            Hours = 32,
            Laboratories = 5
        };

        var firstLesson = new TimePeriod()
        {
            StartTime = DateTime.Now,
            EndTime = DateTime.Now + TimeSpan.FromHours(3),
            WeekDay = WeekDayType.Monday
        };
        
        var fafCab = new Room()
        {
            Capacity = 30,
            Name = "FAF-CAB"
        };
       
        
        await _roomService.Save(fafCab);
        await _timePeriodService.Save(firstLesson);
        await _groupService.Save(faf203);
        await _departmentService.Save(fcim);
        await _subjectService.Save(tmps);

        var lesson = new Lesson()
        {
            Group = faf203,
            GroupId = faf203.Id,
            Name = "Consulatatie FAF-203",
            Subject = tmps,
            SubjectId = tmps.Id,
            WeekType = WeekType.None,
            LessonType = LessonType.Class,
            TimePeriod = firstLesson,
            Room = fafCab,
            RoomId = fafCab.Id,
        };

        await _lessonService.Save(lesson);
    }
}