using Backend.Services.DataImport.Strategy;

namespace Backend.Services.DataImport;

public interface ICsvImport
{
    public Task<bool> ImportData(IFormFile csvFileName);
    public Task SetStrategy(IStrategy strategy);
}