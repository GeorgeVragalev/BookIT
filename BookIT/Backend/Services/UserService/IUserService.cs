using Backend.Entities.Users;

namespace Backend.Services.UserService;

public interface IUserService
{
    public Task Save(User user);
    public Task<User?> GetById(int id);
    IQueryable<User> GetAll();
}