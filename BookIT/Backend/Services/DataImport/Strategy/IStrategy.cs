using CsvHelper;

namespace Backend.Services.DataImport.Strategy;

public interface IStrategy
{
    public Task<bool> Import(CsvReader csvReader);
}