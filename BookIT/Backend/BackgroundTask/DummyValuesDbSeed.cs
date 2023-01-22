using Backend.Services.DummySeedService;

namespace Backend.BackgroundTask;

public class DummyValuesDbSeed: BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public DummyValuesDbSeed(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            await Task.Delay(5000, stoppingToken);
            using var scope = _serviceScopeFactory.CreateScope();
            var clientService = scope.ServiceProvider.GetRequiredService<IDummySeedService>();
            await clientService.SeedDb();
        }
        catch (Exception)
        {
            // ignored
        }
    }
}