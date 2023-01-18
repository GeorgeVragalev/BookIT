using Backend.Services.DataImport.Stategy;

namespace Backend.Services.DataImport;

public interface ICsvImport
{
    public bool ImportData(IFormFile csvFileName);
    public void SetStrategy(IStrategy strategy);
}