using Backend.Helpers;
using Backend.Models;
using Backend.Services.University.DepartmentService;
using CsvHelper;

namespace Backend.Services.DataImport.Strategy;

public class DepartmentImportStrategy : IStrategy
{
    private readonly IDepartmentService _departmentService;

    public DepartmentImportStrategy(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    public async Task<bool> Import(CsvReader csvReader)
    {
        try
        {
            var departmentModels = csvReader.GetRecords<DepartmentModel>().ToList();

            foreach (var model in departmentModels)
            {
                var department = model.ToEntity();
                await _departmentService.Save(department);
            }

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}