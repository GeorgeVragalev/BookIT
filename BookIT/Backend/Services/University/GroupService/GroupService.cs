using Backend.Entities.UniversityEntities;
using Backend.Repositories.University.GroupRepository;

namespace Backend.Services.University.GroupService;

public class GroupService : IGroupService
{
    private readonly IGroupRepository _groupRepository;

    public GroupService(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public IList<Group> GetAll()
    {
        return _groupRepository.GetAll().ToList();
    }

    public Task<Group?> GetById(int id)
    {
        return _groupRepository.GetById(id);
    }

    public Task Save(Group group)
    {
        return _groupRepository.Save(group);
    }

    public Task Update(Group group)
    {
        return _groupRepository.Update(group);
    }

    public Task Delete(Group group)
    {
        return _groupRepository.Delete(group);
    }
}