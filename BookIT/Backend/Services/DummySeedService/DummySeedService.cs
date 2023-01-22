using Backend.Entities.UniversityEntities;
using Backend.Services.University.DepartmentService;
using Backend.Services.University.GroupService;
using Backend.Services.University.SubjectService;

namespace Backend.Services.DummySeedService;

public class DummySeedService : IDummySeedService
{
    private readonly IGroupService _groupService;
    private readonly IDepartmentService _departmentService;
    private readonly ISubjectService _subjectService;

    public DummySeedService(IGroupService groupService, IDepartmentService departmentService, ISubjectService subjectService)
    {
        _groupService = groupService;
        _departmentService = departmentService;
        _subjectService = subjectService;
    }

    public async Task SeedDb()
    {
        var faf203 = new Group()
        {
            Name = "FAF-203"
        };

        var fcim = new Department()
        {
            Name = "FCIM"
        };

        var tmps = new Subject()
        {
            Name = "TMPS",
            Exams = 2,
            Hours = 32,
            Laboratories = 5
        };

        await _groupService.Save(faf203);
        await _departmentService.Save(fcim);
        await _subjectService.Save(tmps);
    }
}