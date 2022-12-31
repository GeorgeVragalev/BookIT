using Backend.Models.Roles;
using Microsoft.AspNetCore.Identity;

namespace Backend.Services.Role;

public class RoleService : IRoleService
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleService(RoleManager<IdentityRole> roleManager)
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
                var identityRole = new IdentityRole()
                {
                    Name = role.ToString()
                };

                await _roleManager.CreateAsync(identityRole);
            }
        }
    }
}