using Backend.Entities.Users;

namespace Backend.Services.UserService;

public interface IUserService
{
    public IList<User> GetAll();
    public Task<User?> GetById(int id);
    public Task<User?> GetByEmail(string email);
    public Task Save(User user);
    public Task Update(User user);
    public Task Delete(User user);
}