using Backend.Entities.Users;
using Backend.Models;

namespace Backend.Helpers;

public static class Mapper
{
    public static User ToEntity(this UserModel model)
    {
        return new User()
        {
            Email = model.Email,
            NormalizedEmail = model.Email.ToUpper()
        };
    } 
}