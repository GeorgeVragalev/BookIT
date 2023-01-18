using System.Globalization;
using Backend.Services.DataImport.Stategy;
using CsvHelper;
using CsvHelper.Configuration;

namespace Backend.Services.DataImport;

public class CsvImport : ICsvImport
{
    private IStrategy _strategy;

    public CsvImport(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public bool ImportData(IFormFile csvFileName)
    {
        using (var reader = new StreamReader(csvFileName.OpenReadStream()))
        using (var csvReader = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
               {
                   PrepareHeaderForMatch = args => args.Header.ToLower(),
                   MissingFieldFound = null,
                   HeaderValidated = null
               }))
        {
            return _strategy.Import(csvReader);
        }
    }

    public void SetStrategy(IStrategy strategy)
    {
        _strategy = strategy;
    }
}