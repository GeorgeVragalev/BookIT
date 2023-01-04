﻿namespace Backend.DependencyRegister;

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
                "register",
                "register",
                defaults: new {controller = "Register", action = "Register"});
            
            endpoints.MapControllerRoute(
                "login",
                "login",
                defaults: new {controller = "Login", action = "Login"});
        });
    }
}