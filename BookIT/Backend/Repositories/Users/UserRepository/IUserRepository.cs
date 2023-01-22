using Backend.Entities.Users;
using Backend.Repositories.GenericRepository;

namespace Backend.Repositories.Users.UserRepository;

public interface IUserRepository : IGenericRepository<User>
{
    public Task<User?> GetByEmail(string email);
}