using Backend.Repositories.GenericRepository;
using Microsoft.AspNetCore.Identity;

namespace Backend.Repositories.UserRepository;

public interface IUserRepository : IGenericRepository<IdentityUser>
{
    
}