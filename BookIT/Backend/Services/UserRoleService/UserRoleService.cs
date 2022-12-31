using Backend.Entities.Roles;
using Backend.Entities.UserRole;
using Backend.Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace Backend.Services.UserRoleService;

public class UserRoleService : IUserRoleService
{
    private IUserRoleStore<User> Store { get; set; }
    private readonly UserManager<User> _userManager;

    public UserRoleService(UserManager<User> userManager, IUserRoleStore<User> store)
    {
        _userManager = userManager;
        Store = store;
    }

    public void Test()
    {
        var user = _userManager.Users.First();
        Store.AddToRoleAsync(user, RoleEnum.Administrator.ToString(), CancellationToken.None);
    }
}