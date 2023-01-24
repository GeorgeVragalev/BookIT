using Backend.Entities.UniversityEntities;
using Backend.Repositories.GenericRepository;

namespace Backend.Repositories.University.GroupRepository;

public class GroupRepository : IGroupRepository
{
    private readonly IGenericRepository<Group> _repository;

    public GroupRepository(IGenericRepository<Group> repository)
    {
        _repository = repository;
    }

    public IQueryable<Group> GetAll()
    {
        return _repository.GetAll();
    }

    public Task<Group?> GetById(int id)
    {
        return _repository.GetById(id);
    }

    public Task Save(Group group)
    {
        return _repository.Save(group);
    }

    public Task Update(Group group)
    {
        return _repository.Update(group);
    }

    public Task Delete(Group group)
    {
        return _repository.Delete(group);
    }

    public Task<Group?> GetByName(string name)
    {
        return Task.FromResult(_repository.GetAll().FirstOrDefault(g => g.Name ==name));
    }
}