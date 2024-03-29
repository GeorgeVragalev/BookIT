﻿
using Backend.Services.RoleService;

namespace Backend.BackgroundTask;

public class BackgroundTask : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public BackgroundTask(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            await Task.Delay(5000, stoppingToken);
            using var scope = _serviceScopeFactory.CreateScope();
            var clientService = scope.ServiceProvider.GetRequiredService<IRoleService>();
            await clientService.CreateRoles();
        }
        catch (Exception)
        {
            // ignored
        }
    }
}