using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace Backend.Services.UserRole;

public class UserRoleService : IUserRoleService
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<IdentityUser> _userManager;


    public UserRoleService(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public void Test()
    {
        var role = _roleManager.Roles;
        var users = _userManager.Users;
    }
}

public interface IUserRoleService
{
    void Test();
}