using System.Globalization;
using Backend.Services.DataImport.Strategy;
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

    public async Task<bool> ImportData(IFormFile csvFileName)
    {
        if (!IsCsvValid(csvFileName))
        {
            return false;
        }
        using (var reader = new StreamReader(csvFileName.OpenReadStream()))
        using (var csvReader = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
               {
                   PrepareHeaderForMatch = args => args.Header.ToLower(),
                   MissingFieldFound = null,
                   HeaderValidated = null
               }))
        {
            return await _strategy.Import(csvReader);
        }
    }

    public bool IsCsvValid(IFormFile file)
    {
        var ext = Path.GetExtension(file.FileName);
        
        if (ext.Equals(".csv"))
        {
            return true;
        }

        return false;
    }


    public Task SetStrategy(IStrategy strategy)
    {
        _strategy = strategy;
        return Task.CompletedTask;
    }
}