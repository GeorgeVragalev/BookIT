using AutoMapper;
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
    }
}