﻿using Backend.Models;
using Backend.Repositories.GenericRepository;
using Backend.Repositories.UserRepository;
using Backend.Services.DataImport;
using Backend.Services.DataImport.Stategy;
using Backend.Services.EmailService;
using Backend.Services.RoleService;
using Backend.Services.UserService;
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
        services.AddScoped<IEmailSender, EmailSender>();
        
        services.AddScoped<IStrategy, UserImportStrategy>();
        services.AddScoped(typeof(ICsvImport), typeof(CsvImport));

        //BackgroundTask
        services.AddHostedService<BackgroundTask.BackgroundTask>();
        
        //Settings
        var emailConfig = configurationManager
            .GetSection("EmailConfiguration")
            .Get<EmailConfiguration>();
        services.AddSingleton(emailConfig);
    }
}