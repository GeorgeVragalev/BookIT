using Backend.Entities.Users;
using Backend.Repositories.UserRepository;

namespace Backend.Services.UserService;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Save(User user)
    {
        await _userRepository.Save(user);
    }

    public Task<User?> GetById(int id)
    {
        return _userRepository.GetById(id);
    }

    public IQueryable<User> GetAll()
    {
        return _userRepository.GetAll();
    }
}