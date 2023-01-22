using AutoMapper;
using Backend.Entities.UniversityEntities;
using Backend.Helpers;
using Backend.Models;
using Backend.Services.University.DepartmentService;
using Backend.Services.University.GroupService;
using Backend.Services.University.SubjectService;
using CsvHelper;

namespace Backend.Services.DataImport.Strategy;

public class SubjectImportStrategy : IStrategy
{
    private readonly ISubjectService _subjectService;

    public SubjectImportStrategy(ISubjectService subjectService)
    {
        _subjectService = subjectService;
    }

    public async Task<bool> Import(IMapper mapper, CsvReader csvReader)
    {
        try
        {
            var subjectModels = csvReader.GetRecords<SubjectModel>().ToList();

            foreach (var model in subjectModels)
            {
                var subject = mapper.Map<Subject>(model);
                await _subjectService.Save(subject);
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