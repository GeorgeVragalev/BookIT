using CsvHelper;

namespace Backend.Services.DataImport.Stategy;

public interface IStrategy
{
    public bool Import(CsvReader csvReader);
    public bool IsCsvValid(CsvReader csvReader);
}