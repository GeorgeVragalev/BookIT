using Backend.Services.UserRole;

namespace Backend.BackgroundTask;

public class TestingBackgroundTask : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public TestingBackgroundTask(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            await Task.Delay(5000, stoppingToken);
            using var scope = _serviceScopeFactory.CreateScope();
            var clientService = scope.ServiceProvider.GetRequiredService<IUserRoleService>();
            clientService.Test();
        }
        catch (Exception)
        {
            // ignored
        }
    }
}