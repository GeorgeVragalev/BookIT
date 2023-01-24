using Backend.Entities.UniversityEntities;
using Backend.Repositories.GenericRepository;

namespace Backend.Repositories.University.DepartmentRepository;

public interface IDepartmentRepository : IGenericRepository<Department>
{
    public Task<Department?> GetByName(string name);
}