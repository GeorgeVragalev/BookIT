﻿using Backend.Data;
using Backend.DependencyRegister;
using Backend.Entities.Roles;
using Backend.Entities.Users;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RouteBuilder = Backend.DependencyRegister.RouteBuilder;


namespace Backend;

public class Startup
{
    private readonly ConfigurationManager _configurationManager;

    public Startup(ConfigurationManager configurationManager)
    {
        _configurationManager = configurationManager;
    }

    public void ConfigureServices(IServiceCollection serviceCollection)
    {
        // Add services to the container.
        var connectionString = _configurationManager.GetConnectionString("DefaultConnection");

        serviceCollection.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));
        serviceCollection.AddDatabaseDeveloperPageExceptionFilter();

        serviceCollection.AddIdentity<User, Role>(options => options.SignIn.RequireConfirmedAccount = true)
            // .AddRoles<Role>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders()
            .AddDefaultUI();

        serviceCollection.AddControllersWithViews();

        serviceCollection.AddRazorPages();

        serviceCollection.AddAuthorization(options =>
        {
            options.AddPolicy("SuperAdmin",
                policy => policy.RequireRole("SuperAdmin"));
        });
        serviceCollection.Configure<CookiePolicyOptions>(options =>
        {
            options.CheckConsentNeeded = context => true;
            options.MinimumSameSitePolicy = SameSiteMode.Strict;
        });
        RegisterDependencies.Register(serviceCollection, _configurationManager);
    }

    public void Configure(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
        {
            // app.UseExceptionHandler("/Home/Error");
            app.UseExceptionHandler("/Error/Error");
            app.UseHsts();
            app.UseCookiePolicy();
            // app.UseCookiePolicy(new CookiePolicyOptions()
            // {
            //     HttpOnly = HttpOnlyPolicy.Always,
            //     Secure = CookieSecurePolicy.Always,
            //     MinimumSameSitePolicy = SameSiteMode.None
            // });
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRequestLocalization();
        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        RouteBuilder.Route(app);
        app.MapRazorPages();
        app.Run();
    }
}