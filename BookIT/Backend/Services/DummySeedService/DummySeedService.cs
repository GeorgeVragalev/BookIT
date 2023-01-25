using Backend.Entities.LessonEntities;
using Backend.Entities.Rooms;
using Backend.Entities.UniversityEntities;
using Backend.Entities.Users;
using Backend.Services.Rooms.FacilityService;
using Backend.Services.Rooms.RoomService;
using Backend.Services.University.DepartmentService;
using Backend.Services.University.GroupService;
using Backend.Services.University.LessonService;
using Backend.Services.University.SubjectService;
using Backend.Services.University.TimePeriodService;
using Backend.Services.Users.TeacherService;
using Backend.Services.Users.UserService;

namespace Backend.Services.DummySeedService;

public class DummySeedService : IDummySeedService
{
    /*private readonly IGroupService _groupService;
    private readonly IDepartmentService _departmentService;
    private readonly ISubjectService _subjectService;
    private readonly ITeacherService _teacherService;
    private readonly ILessonService _lessonService;
    private readonly ITimePeriodService _timePeriodService;
    private readonly IRoomService _roomService;
    private readonly IFacilityService _facilityService;
    private readonly IUserService _userService;

    public DummySeedService(IGroupService groupService, IDepartmentService departmentService, ISubjectService subjectService, ILessonService lessonService, ITeacherService teacherService, ITimePeriodService timePeriodService, IRoomService roomService, IFacilityService facilityService, IUserService userService)
    {
        _groupService = groupService;
        _departmentService = departmentService;
        _subjectService = subjectService;
        _lessonService = lessonService;
        _teacherService = teacherService;
        _timePeriodService = timePeriodService;
        _roomService = roomService;
        _facilityService = facilityService;
        _userService = userService;
    }

    public async Task SeedDb()
    {
        await UpdateUser();
        
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
            Name = "FAF-CAB",
        };
        
        if (_roomService.GetAll().Count == 0)
        {
            await _roomService.Save(fafCab);
        }

        if (_groupService.GetAll().Count == 0)
        {
            await _groupService.Save(faf203);
        }
        
        var table = new Facility()
        {
            Quantity = 5,
            FacilityType = FacilityType.Table,
            Room = fafCab,
            RoomId = fafCab.Id
        };
        
        if (_facilityService.GetAll().Count == 0)
        {
            await _facilityService.Save(table);
        }
        
        if (_departmentService.GetAll().Count == 0)
        {
            await _departmentService.Save(fcim);
        }
        
        if (_subjectService.GetAll().Count == 0)
        {
            await _subjectService.Save(tmps);
        }
        
        if (_timePeriodService.GetAll().Count == 0)
        {
            await _timePeriodService.Save(firstLesson);
        }

        var teacher = new Teacher()
        {
            Department = fcim,
            DepartmentId = fcim.Id,
            Quote = "If you reach it",

        };
            
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
            // Teacher = teacher,
            // TeacherId = teacher.Id
        };
        
        if (_lessonService.GetAll().Count == 0)
        {
            await _lessonService.Save(lesson);
        }
    }

    public async Task AddNewLesson()
    {
          var faf203 = await _groupService.GetByName("FAF-203");
          var fcim = await _departmentService.GetByName("FCIM");
          var fafCab = await _roomService.GetByName("FAF-CAB");


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
            WeekDay = (WeekDayType) DateTime.Today.DayOfWeek
        };

        if (_timePeriodService.GetAll().Count == 0)
        {
            await _timePeriodService.Save(firstLesson);
        }

        var teacher = await _teacherService.GetByEmail("alex.vdov@isa.utm.md");
            
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
            RoomId = fafCab?.Id,
            Teacher = teacher,
            TeacherId = teacher?.Id
        };
        
        if (_lessonService.GetAll().Count == 0)
        {
            await _lessonService.Save(lesson);
        }
    }


    public async Task UpdateUser()
    {
        var faf203 = await _groupService.GetByName("FAF-203");
          
        //change to your admin account
        var user = await _userService.GetByEmail("Vragalevgeorge1@gmail.com");

        if (user != null && user.Student != null)
        {
            user.Student = new Student()
            {
                Group = faf203,
                User = user,
                UserId = user.Id
            };

            await _userService.Update(user);
        }
    }*/
}