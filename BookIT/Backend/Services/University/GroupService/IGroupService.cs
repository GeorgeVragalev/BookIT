using Backend.Entities.UniversityEntities;

namespace Backend.Services.University.GroupService;

public interface IGroupService
{
    public IList<Group> GetAll();
    public Task<Group?> GetById(int id);
    public Task<Group?> GetByName(string group);
    public Task Save(Group group);
    public Task Update(Group group);
    public Task Delete(Group group);
}