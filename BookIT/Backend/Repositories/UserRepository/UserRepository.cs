using Backend.Entities.Users;
using Backend.Repositories.GenericRepository;

namespace Backend.Repositories.UserRepository;

public class UserRepository : IUserRepository
{
    private readonly IGenericRepository<User> _repository;

    public UserRepository(IGenericRepository<User> repository)
    {
        _repository = repository;
    }

    public Task<List<User>> GetAll()
    {
        return _repository.GetAll();
    }

    public Task<User?> GetById(int id)
    {
        return _repository.GetById(id);
    }

    public Task Save(User item)
    {
        return _repository.Save(item);
    }

    public Task Update(User item)
    {
        return _repository.Update(item);
    }

    public Task Delete(User item)
    {
        return _repository.Delete(item);
    }
}