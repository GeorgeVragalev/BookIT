using Backend.Entities.UniversityEntities;
using Backend.Repositories.University.DepartmentRepository;
using Backend.Services.University.DepartmentService;

namespace Backend.Services.University.SubjectService;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public IList<Department> GetAll()
    {
        return _departmentRepository.GetAll().ToList();
    }

    public Task<Department?> GetById(int id)
    {
        return _departmentRepository.GetById(id);
    }

    public Task Save(Department department)
    {
        return _departmentRepository.Save(department);
    }

    public Task Update(Department department)
    {
        return _departmentRepository.Update(department);
    }

    public Task Delete(Department department)
    {
        return _departmentRepository.Delete(department);
    }
}