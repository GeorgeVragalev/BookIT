using System.Globalization;
using Backend.Entities.Users;
using Backend.Services.DataImport.Stategy;
using CsvHelper;
using CsvHelper.Configuration;

namespace Backend.Services.DataImport;

public class CsvImport : ICsvImport
{
    private readonly IStrategy _strategy;

    public CsvImport(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public bool ImportData(string csvFileName)
    {
        using var streamReader = File.OpenText(csvFileName);
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            PrepareHeaderForMatch = args => args.Header.ToLower(),
            MissingFieldFound = null,
            HeaderValidated = null
        };
        
        using var csvReader = new CsvReader(streamReader, config);
        
        return _strategy.Import(csvReader);
    }
}