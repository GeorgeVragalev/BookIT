using Backend.Entities.Roles;
using Microsoft.AspNetCore.Identity;

namespace Backend.Services.RoleService;

public class RoleService : IRoleService
{
    private readonly RoleManager<Role> _roleManager;

    public RoleService(RoleManager<Role> roleManager)
    {
        _roleManager = roleManager;
    }
    
    public async Task CreateRoles()
    {
        foreach (var role in (RoleEnum[]) Enum.GetValues(typeof(RoleEnum)))
        {
            var roleExists = await _roleManager.RoleExistsAsync(role.ToString());

            if (!roleExists)
            {
                var identityRole = new Role
                {
                    Name = role.ToString()
                };

                await _roleManager.CreateAsync(identityRole);
            }
        }
    }
}