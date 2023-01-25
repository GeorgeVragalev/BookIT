using Backend.Entities.Users;
using Backend.Repositories.GenericRepository;

namespace Backend.Repositories.Users.UserRepository;

public interface IUserRepository
{
    public Task<User?> GetByEmail(string email);
    public IQueryable<User> GetAll();
    public Task<User?> GetById(int id);
    public Task Save(User item);
    public Task Update(User item);
    public Task Delete(User item);
}