using Backend.Entities.Users;
using Backend.Repositories.GenericRepository;
using Microsoft.AspNetCore.Identity;

namespace Backend.Repositories.UserRepository;

public class UserRepository : IUserRepository
{
    private readonly IGenericRepository<User> _repository;
    private readonly UserManager<User> _userManager;
    private readonly IUserStore<User> _userStore;
    public UserRepository(IGenericRepository<User> repository, UserManager<User> userManager, IUserStore<User> userStore)
    {
        _repository = repository;
        _userManager = userManager;
        _userStore = userStore;
    }

    public IQueryable<User> GetAll()
    {
        return _userManager.Users;
    }

    public Task<User?> GetById(int id)
    {
        return _repository.GetById(id);
    }

    public Task<User?> GetByEmail(string email)
    {
        return Task.FromResult(GetAll().FirstOrDefault(user => user.Email.Equals(email)));
    }

    public Task Save(User user)
    {
        _userStore.SetUserNameAsync(user, user.Email, CancellationToken.None); 
        user.EmailConfirmed = true;
        user.PhoneNumberConfirmed = true; 
        return _userManager.CreateAsync(user, user.PasswordHash);
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