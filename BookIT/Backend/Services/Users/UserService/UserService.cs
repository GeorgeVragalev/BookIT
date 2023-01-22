using Backend.Entities.Users;
using Backend.Repositories.Users.UserRepository;

namespace Backend.Services.Users.UserService;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public IList<User> GetAll()
    {
        return _userRepository.GetAll().ToList();
    }

    public Task<User?> GetById(int id)
    {
        return _userRepository.GetById(id);
    }

    public Task<User?> GetByEmail(string email)
    {
        return _userRepository.GetByEmail(email);
    }

    public Task Save(User user)
    {
        return _userRepository.Save(user);
    }

    public Task Update(User user)
    {
        return _userRepository.Update(user);
    }

    public Task Delete(User user)
    {
        return _userRepository.Delete(user);
    }
}