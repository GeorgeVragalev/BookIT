using Backend.Entities.UniversityEntities;
using Backend.Repositories.GenericRepository;

namespace Backend.Repositories.University.GroupRepository;

public interface IGroupRepository
{
    public Task<Group?> GetByName(string name);
    public IQueryable<Group> GetAll();
    public Task<Group?> GetById(int id);
    public Task Save(Group item);
    public Task Update(Group item);
    public Task Delete(Group item);
}