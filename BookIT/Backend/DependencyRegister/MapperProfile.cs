using AutoMapper;
using Backend.Entities.LessonEntities;
using Backend.Entities.Rooms;
using Backend.Entities.UniversityEntities;
using Backend.Entities.Users;
using Backend.Models;

namespace Backend.DependencyRegister;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<User, UserModel>().ReverseMap();
        CreateMap<Teacher, TeacherModel>().ReverseMap();
        CreateMap<Student, StudentModel>().ReverseMap();
        CreateMap<Department, DepartmentModel>().ReverseMap();
        CreateMap<Group, GroupModel>().ReverseMap();
        CreateMap<Subject, SubjectModel>().ReverseMap();
        CreateMap<Room, RoomModel>().ReverseMap();
        CreateMap<Facility, FacilityModel>().ReverseMap();
        CreateMap<Lesson, LessonModel>().ReverseMap();
        CreateMap<TimePeriod, TimePeriodModel>().ReverseMap();

        CreateMap<Lesson, EventModel>()
            .ForMember(dest =>
                    dest.group,
                opt => opt.MapFrom(src => (src.Group != null) ? src.Group.Name : ""))
            .ForMember(dest =>
                    dest.subject,
                opt => opt.MapFrom(src => (src.Subject != null) ? src.Subject.Name : ""))
            .ForMember(dest =>
                    dest.room,
                opt => opt.MapFrom(src => (src.Room != null) ? src.Room.Name : ""))
            .ForMember(dest =>
                    dest.teacher,
                opt => opt.MapFrom(src =>
                    (src.Teacher != null && src.Teacher.User != null)
                        ? src.Teacher.User.FirstName + src.Teacher.User.LastName
                        : ""))
            .ForMember(dest =>
                    dest.title,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(dest =>
                    dest.start,
                opt => opt.MapFrom(src => src.TimePeriod.StartTime.ToString("MM/dd/yyyy") + " " + src.TimePeriod.StartTime.ToString("HH:mm")))
            .ForMember(dest =>
                    dest.end,
                opt => opt.MapFrom(src => src.TimePeriod.EndTime.ToString("MM/dd/yyyy") + " " + src.TimePeriod.EndTime.ToString("HH:mm"))).ReverseMap();
    }
}