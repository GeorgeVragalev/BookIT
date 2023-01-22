using Backend.Entities.Roles;
using Backend.Entities.Rooms;
using Backend.Entities.UniversityEntities;
using Backend.Entities.Users;
using Backend.Models;

namespace Backend.Helpers;

public static class Mapper
{
    public static User ToEntity(this UserModel model)
    {
        return new User()
        {
            Email = model.Email,
            NormalizedEmail = model.Email.ToUpper()
        };
    }
    
    public static Group ToEntity(this GroupModel model)
    {
        return new Group()
        {
            Name = model.Name
        };
    }
    
    public static Department ToEntity(this DepartmentModel model)
    {
        var teachers = model.Teachers.Select(s => s.ToEntity()).ToList();

        return new Department()
        {
            Name = model.Name,
            Teachers = teachers
        };
    }
    
    public static Subject ToEntity(this SubjectModel model)
    {
        var teachers = model.Teachers.Select(s => s.ToEntity()).ToList();

        return new Subject()
        {
            Name = model.Name,
            Exams = model.Exams,
            Hours = model.Hours,
            Laboratories = model.Laboratories,
            Teachers = teachers
        };
    }
    
    public static Teacher ToEntity(this TeacherModel model)
    {
        var subjects = model.Subjects.Select(s => s.ToEntity()).ToList();
        return new Teacher()
        {
            Department = model.Department.ToEntity(),
            Quote = model.Quote,
            User = model.User.ToEntity(),
            AboutMe = model.AboutMe,
            DepartmentId = model.Department.Id, 
            Subjects = subjects
        };
    }
    
    
    public static RoomModel ToModel(this Room room)
    {
        return new RoomModel()
        {
            Id = room.Id,
            Capacity = room.Capacity,
            Name = room.Name,
            Facilities = room.Facilities.Select(f => f.ToModel()).ToList(),
            FacilityString = PrepareFacilityString(room.Facilities)
        };
    }
    
    public static UserModel ToModel(this User user)
    {
        return new UserModel()
        {
            Id = user.Id,
            Email = user.Email, 
            TeacherModel = user?.Teacher?.ToModel(),
            StudentModel = user?.Student?.ToModel(),
            Role = RoleEnum.Student
        };
    }
    
    public static TeacherModel ToModel(this Teacher teacher)
    {
        var subjects = teacher.Subjects.Select(s => s.ToModel()).ToList();
        return new TeacherModel()
        {
            Id = teacher.Id,
            Department = teacher.Department.ToModel(),
            Quote = teacher.Quote,
            Subjects = subjects
        };
    }

    public static StudentModel ToModel(this Student student)
    {
        return new StudentModel()
        {
            Id = student.Id,
            Group = student.Group.ToModel(),
            User = student.User.ToModel(),
            AboutMe = student.AboutMe, 
        };
    }
    
    public static IList<RoomModel> ToModel(this IList<Room> models)
    {
        return models.Select(room => room.ToModel()).ToList();
    }

    private static string ListToString<T>(this IEnumerable<T> roomFacilities)
    {
        return string.Join(", ", roomFacilities.ToArray());
    }

    public static FacilityModel ToModel(this Facility facility)
    {
        return new FacilityModel()
        {
            Id = facility.Id,
            Quantity = facility.Quantity,
            FacilityType = facility.FacilityType
        };
    }
    
    public static DepartmentModel ToModel(this Department department)
    {
        var teachers = department.Teachers.Select(t => t.ToModel()).ToList();
        
        return new DepartmentModel()
        {
            Id = department.Id,
            Name = department.Name,
            Teachers = teachers
        };
    }
    
    public static SubjectModel ToModel(this Subject subject)
    {
        var teachers = subject.Teachers?.Select(t => t.ToModel()).ToList();

        return new SubjectModel()
        {
            Id = subject.Id,
            Exams = subject.Exams,
            Hours = subject.Hours,
            Laboratories = subject.Laboratories,
            Teachers = teachers,
            Name = subject.Name
        };
    }
    
    public static GroupModel ToModel(this Group group)
    {
        var students = group.Students.Select(s => s.ToModel()).ToList();
        return new GroupModel()
        {
            Id = group.Id,
            Name = group.Name,
            Students = students
        };
    }

    private static string PrepareFacilityString(IEnumerable<Facility> roomFacilities)
    {
        return string.Join(", ", roomFacilities.Select(roomFacility => roomFacility.FacilityType.ToString()).ToArray());
    }
}