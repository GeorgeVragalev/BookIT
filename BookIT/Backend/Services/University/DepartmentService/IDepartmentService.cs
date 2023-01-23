using Backend.Entities.UniversityEntities;

namespace Backend.Services.University.DepartmentService;

public interface IDepartmentService
{
    public IList<Department> GetAll();
    public Task<Department?> GetById(int id);
    public Task<Department?> GetByName(string department);
    public Task Save(Department department);
    public Task Update(Department department);
    public Task Delete(Department department);
}