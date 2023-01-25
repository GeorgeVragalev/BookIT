using Backend.Entities.Shared;
using Microsoft.AspNetCore.Identity;

namespace Backend.Entities.Roles;

public class Role : IdentityRole<int>, BaseEntity
{
}