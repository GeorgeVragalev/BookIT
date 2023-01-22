using AutoMapper;
using CsvHelper;

namespace Backend.Services.DataImport.Strategy;

public interface IStrategy
{
    public Task<bool> Import(IMapper mapper, CsvReader csvReader);
}