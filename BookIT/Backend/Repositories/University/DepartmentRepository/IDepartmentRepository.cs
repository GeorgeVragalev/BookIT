using Backend.Entities.UniversityEntities;
using Backend.Repositories.GenericRepository;

namespace Backend.Repositories.University.DepartmentRepository;

public interface IDepartmentRepository
{
    public Task<Department?> GetByName(string name);
    public IQueryable<Department> GetAll();
    public Task<Department?> GetById(int id);
    public Task Save(Department item);
    public Task Update(Department item);
    public Task Delete(Department item);
}