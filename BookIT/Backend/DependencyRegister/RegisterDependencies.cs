﻿using Backend.Models;
using Backend.Repositories.GenericRepository;
using Backend.Repositories.UserRepository;
using Backend.Services.DataImport;
using Backend.Services.DataImport.Strategy;
using Backend.Services.EmailService;
using Backend.Services.ReCaptcha;
using Backend.Services.RoleService;
using Backend.Services.UserService;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity.UI.Services;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;

namespace Backend.DependencyRegister;

public static class RegisterDependencies
{
    //Register all the dependencies
    public static void Register(IServiceCollection services, ConfigurationManager configurationManager)
    {
        //Repository
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        //Services
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IEmailService, EmailService>();
        
        services.AddScoped<IStrategy, UserImportStrategy>();
        services.AddScoped(typeof(ICsvImport), typeof(CsvImport));

        services.AddScoped<IReCaptchaService, ReCaptchaService>();
        
        //BackgroundTask
        services.AddHostedService<BackgroundTask.BackgroundTask>();
        
        //Settings
        var emailConfig = configurationManager
            .GetSection("EmailConfiguration")
            .Get<EmailConfiguration>();
        services.AddSingleton(emailConfig);

        services.Configure<CookiePolicyOptions>(options =>
        {
            // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            options.CheckConsentNeeded = context => true;
            options.MinimumSameSitePolicy = SameSiteMode.None; 
        }); 
    }
}