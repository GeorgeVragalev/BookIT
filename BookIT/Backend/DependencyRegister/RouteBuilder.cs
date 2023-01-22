namespace Backend.DependencyRegister;

public static class RouteBuilder
{
    public static void Route(WebApplication app)
    {
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                "create-user",
                "create-user",
                defaults: new {controller = "Admin", action = "CreateUser"});
            
            endpoints.MapControllerRoute(
                "reset-password",
                "reset-password",
                defaults: new {controller = "ForgotPassword", action = "ForgotPassword"});
            
            endpoints.MapControllerRoute(
                "rooms",
                "rooms",
                defaults: new {controller = "Room", action = "Rooms"});
            
            endpoints.MapControllerRoute(
                "users",
                "users",
                defaults: new {controller = "User", action = "UsersList"});
            
            endpoints.MapControllerRoute(
                "import",
                "import",
                defaults: new {controller = "Import", action = "Users"});
        });
    }
}