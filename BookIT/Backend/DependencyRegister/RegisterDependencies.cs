using Backend.Repositories.GenericRepository;
using Backend.Repositories.UserRepository;
using Backend.Services.Role;
using Backend.Services.UserRole;

namespace Backend.DependencyRegister;

public static class RegisterDependencies
{
    //Register all the dependencies
    public static void Register(IServiceCollection services)
    {
        //Repository
        services.AddScoped<IUserRepository, UserRepository>();
        
        //Services
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IUserRoleService, UserRoleService>();

        //Generic
        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        //BackgroundTask
        services.AddHostedService<BackgroundTask.BackgroundTask>();
        services.AddHostedService<BackgroundTask.TestingBackgroundTask>();
    }
}