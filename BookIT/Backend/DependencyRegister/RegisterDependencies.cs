
namespace Backend.DependencyRegister;

public static class RegisterDependencies
{
    //Register all the dependencies
    public static void Register(IServiceCollection services)
    {
        
        //Services
        // services.AddScoped<IRoleService, RoleService>();
        // services.AddScoped<IUserRoleService, UserRoleService>();

        //BackgroundTask
        services.AddHostedService<BackgroundTask.BackgroundTask>();
        services.AddHostedService<BackgroundTask.TestingBackgroundTask>();
    }
}