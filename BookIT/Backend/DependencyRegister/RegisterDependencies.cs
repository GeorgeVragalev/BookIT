using Backend.Repositories.GenericRepository;
using Backend.Repositories.UserRepository;
using Backend.Services.RoleService;
using Backend.Services.UserService;

namespace Backend.DependencyRegister;

public static class RegisterDependencies
{
    //Register all the dependencies
    public static void Register(IServiceCollection services)
    {
        //Repository
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        //Services
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IUserService, UserService>();

        //BackgroundTask
        services.AddHostedService<BackgroundTask.BackgroundTask>();
    }
}