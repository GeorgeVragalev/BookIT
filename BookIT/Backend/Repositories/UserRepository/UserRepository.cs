using Backend.Repositories.GenericRepository;
using Microsoft.AspNetCore.Identity;

namespace Backend.Repositories.UserRepository;

public class UserRepository : IUserRepository
{
    private readonly IGenericRepository<IdentityUser> _repository;

    public UserRepository(IGenericRepository<IdentityUser> repository)
    {
        _repository = repository;
    }

    public Task<List<IdentityUser>> GetAll()
    {
        return _repository.GetAll();
    }

    public Task<IdentityUser?> GetById(int id)
    {
        return _repository.GetById(id);
    }

    public Task<IdentityUser?> GetById(string id)
    {
        return _repository.GetById(id);
    }

    public Task Save(IdentityUser item)
    {
        return _repository.Save(item);
    }

    public Task Update(IdentityUser item)
    {
        return _repository.Update(item);
    }

    public Task Delete(IdentityUser item)
    {
        return _repository.Delete(item);
    }
}