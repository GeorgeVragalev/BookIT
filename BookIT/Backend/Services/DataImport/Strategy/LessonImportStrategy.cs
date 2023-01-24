using AutoMapper;
using Backend.Entities.LessonEntities;
using Backend.Entities.Roles;
using Backend.Entities.Rooms;
using Backend.Entities.UniversityEntities;
using Backend.Entities.UserRole;
using Backend.Entities.Users;
using Backend.Helpers;
using Backend.Models;
using Backend.Services.Rooms.RoomService;
using Backend.Services.University.DepartmentService;
using Backend.Services.University.GroupService;
using Backend.Services.University.LessonService;
using Backend.Services.University.SubjectService;
using Backend.Services.University.TimePeriodService;
using Backend.Services.Users.StudentService;
using Backend.Services.Users.TeacherService;
using Backend.Services.Users.UserService;
using CsvHelper;
using Microsoft.AspNetCore.Identity;

namespace Backend.Services.DataImport.Strategy;

public class LessonImportStrategy : IStrategy
{
    private readonly ITeacherService _teacherService;
    private readonly IStudentService _studentService;
    private readonly IUserService _userService;
    private readonly IDepartmentService _departmentService;
    private readonly ISubjectService _subjectService;
    private readonly IRoomService _roomService;
    private readonly IGroupService _groupService;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly ITimePeriodService _timePeriodService;
    private readonly ILessonService _lessonService;


    public LessonImportStrategy(ITeacherService teacherService, IStudentService studentService,
        IUserService userService, IDepartmentService departmentService, ISubjectService subjectService,
        IRoomService roomService, IGroupService groupService, IMapper mapper, UserManager<User> userManager,
        ITimePeriodService timePeriodService, ILessonService lessonService)
    {
        _teacherService = teacherService;
        _studentService = studentService;
        _userService = userService;
        _departmentService = departmentService;
        _subjectService = subjectService;
        _roomService = roomService;
        _groupService = groupService;
        this._mapper = mapper;
        _userManager = userManager;
        _timePeriodService = timePeriodService;
        _lessonService = lessonService;
    }

    public async Task<bool> Import(IMapper mapper, CsvReader csvReader)
    {
        try
        {
            var lessonImportModels = csvReader.GetRecords<LessonImportModel>().ToList();

            foreach (var model in lessonImportModels)
            {
                Room? room = null;
                if (!string.IsNullOrEmpty(model.RoomName))
                {
                    room = await GetRoomByName(model.RoomName);
                }

                Group? group = null;
                if (!string.IsNullOrEmpty(model.Group))
                {
                    group = await GetGroupByName(model.Group);
                }

                Subject? subject = null;
                if (!string.IsNullOrEmpty(model.Subject))
                {
                    subject = await GetSubjectByName(model.Subject);
                }

                Teacher? teacher = null;
                if (!string.IsNullOrEmpty(model.TeacherEmail))
                {
                    teacher = await GetTeacherByEmail(model.TeacherEmail);
                }

                for (var occurence = 0; occurence < model.NumberOfLessons; occurence++)
                {
                    var timePeriod = await GetTimePeriod(model.StartTime, model.EndTime, model.WeeklySeparation, occurence);
                    
                    var lesson = new Lesson()
                    {
                        Room = room,
                        RoomId = room?.Id,
                        Group = group,
                        GroupId = group?.Id,
                        Name = model.Name,
                        Subject = subject,
                        SubjectId = subject?.Id,
                        Teacher = teacher,
                        TeacherId = teacher?.Id,
                        LessonType = model.LessonType,
                        TimePeriod = timePeriod,
                        TimePeriodId = timePeriod.Id,
                        WeekType = model.WeekType
                    };
                    
                    await _lessonService.Save(lesson);
                }

            }

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    private async Task<Room?> GetRoomByName(string roomName)
    {
        if (!string.IsNullOrEmpty(roomName))
        {
            var room = await _roomService.GetByName(roomName);
            if (room != null)
            {
                return room;
            }

            var roomModel = new RoomModel()
            {
                Name = roomName,
                Capacity = 10
            };

            room = _mapper.Map<Room>(roomModel);

            await _roomService.Save(room);

            return room;
        }

        return null;
    }

    private async Task<Group?> GetGroupByName(string groupName)
    {
        if (!string.IsNullOrEmpty(groupName))
        {
            var group = await _groupService.GetByName(groupName);
            if (group != null)
            {
                return group;
            }

            var groupModel = new GroupModel()
            {
                Name = groupName
            };

            group = _mapper.Map<Group>(groupModel);

            await _groupService.Save(group);

            return group;
        }

        return null;
    }

    private async Task<Subject?> GetSubjectByName(string subjectName)
    {
        if (!string.IsNullOrEmpty(subjectName))
        {
            var subject = await _subjectService.GetByName(subjectName);
            if (subject != null)
            {
                return subject;
            }

            var subjectModel = new SubjectModel()
            {
                Name = subjectName
            };

            subject = _mapper.Map<Subject>(subjectModel);

            await _subjectService.Save(subject);

            return subject;
        }

        return null;
    }

    private async Task<Teacher?> GetTeacherByEmail(string teacherEmail)
    {
        if (!string.IsNullOrEmpty(teacherEmail))
        {
            var teacher = await _teacherService.GetByEmail(teacherEmail);

            if (teacher != null)
            {
                return teacher;
            }

            var user = UserGenerator.GenerateUserFromEmail(teacherEmail);
            await _userService.Save(user);
            await _userManager.AddToRoleAsync(user, RoleEnum.Teacher.ToString());

            teacher = new Teacher()
            {
                User = user,
                UserId = user.Id
            };

            await _teacherService.Save(teacher);

            return teacher;
        }

        return null;
    }

    private async Task<TimePeriod> GetTimePeriod(string startTime, string endTime, int weeklySeparation, int occurence)
    {
        var start = DateTime.ParseExact(startTime, "yyyy-MM-dd HH:mm tt", null).AddDays(7 * weeklySeparation * occurence);
        var end = DateTime.ParseExact(endTime, "yyyy-MM-dd HH:mm tt", null).AddDays(7 * weeklySeparation * occurence);
        // string iString = "2005-05-05 22:12 PM";
        var timePeriod = new TimePeriod()
        {
            StartTime = start,
            EndTime = end,
            WeekDay = (WeekDayType) start.DayOfWeek
        };

        await _timePeriodService.Save(timePeriod);

        return timePeriod;
    }
}