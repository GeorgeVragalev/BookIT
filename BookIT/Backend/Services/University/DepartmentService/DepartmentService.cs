using Backend.Entities.UniversityEntities;
using Backend.Repositories.University.DepartmentRepository;

namespace Backend.Services.University.DepartmentService;

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

    public Task<Department?> GetByName(string department)
    {
        return _departmentRepository.GetByName(department);
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