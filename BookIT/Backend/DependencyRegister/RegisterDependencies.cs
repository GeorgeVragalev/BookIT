using Backend.BackgroundTask;
using Backend.Models;
using Backend.Repositories.GenericRepository;
using Backend.Repositories.Rooms.FacilityRepository;
using Backend.Repositories.Rooms.RoomRepository;
using Backend.Repositories.University.DepartmentRepository;
using Backend.Repositories.University.GroupRepository;
using Backend.Repositories.University.SubjectRepository;
using Backend.Repositories.Users.StudentRepository;
using Backend.Repositories.Users.TeacherRepository;
using Backend.Repositories.Users.UserRepository;
using Backend.Services.DataImport;
using Backend.Services.DataImport.Strategy;
using Backend.Services.DummySeedService;
using Backend.Services.EmailService;
using Backend.Services.ReCaptcha;
using Backend.Services.RoleService;
using Backend.Services.Rooms.FacilityService;
using Backend.Services.Rooms.RoomService;
using Backend.Services.University.DepartmentService;
using Backend.Services.University.GroupService;
using Backend.Services.University.SubjectService;
using Backend.Services.Users.StudentService;
using Backend.Services.Users.TeacherService;
using Backend.Services.Users.UserService;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;

namespace Backend.DependencyRegister;

public static class RegisterDependencies
{
    //Register all the dependencies
    public static void Register(IServiceCollection services, ConfigurationManager configurationManager)
    {
        //Repository
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITeacherRepository, TeacherRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();
        services.AddScoped<IFacilityRepository, FacilityRepository>();
        services.AddScoped<ISubjectRepository, SubjectRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IGroupRepository, GroupRepository>();

        //Services
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<ITeacherService, TeacherService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IRoomService, RoomService>();
        services.AddScoped<IFacilityService, FacilityService>();
        services.AddScoped<IGroupService, GroupService>();
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<ISubjectService, SubjectService>();
        
        //Csv import
        services.AddScoped<IStrategy, UserImportStrategy>();
        services.AddScoped<IStrategy, DepartmentImportStrategy>();
        services.AddScoped(typeof(ICsvImport), typeof(CsvImport));

        //Special services
        services.AddScoped<IReCaptchaService, ReCaptchaService>();
        services.AddScoped<IDummySeedService, DummySeedService>();
        
        //BackgroundTask
        services.AddHostedService<BackgroundTask.BackgroundTask>();
        services.AddHostedService<DummyValuesDbSeed>();
        
        //Settings
        var emailConfig = configurationManager
            .GetSection("EmailConfiguration")
            .Get<EmailConfiguration>();
        services.AddSingleton(emailConfig);
    }
}