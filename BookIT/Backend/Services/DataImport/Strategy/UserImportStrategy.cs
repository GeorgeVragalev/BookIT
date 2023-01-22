using Backend.Entities.Users;
using Backend.Helpers;
using Backend.Models;
using Backend.Services.Users.UserService;
using CsvHelper;
using Microsoft.AspNetCore.Identity;
using PasswordGenerator;

namespace Backend.Services.DataImport.Strategy;

public class UserImportStrategy : IStrategy
{
    private readonly IUserService _userService;
    private readonly UserManager<User> _userManager;

    public UserImportStrategy(IUserService userService, UserManager<User> userManager)
    {
        _userService = userService;
        _userManager = userManager;
    }

    public async Task<bool> Import(CsvReader csvReader)
    {
        try
        {
            var userModels = csvReader.GetRecords<UserModel>().ToList();

            foreach (var model in userModels)
            {
                var user = model.ToEntity();
                SetUserProperties(user);
                await _userService.Save(user); 
                await _userManager.AddToRoleAsync(user, model.Role.ToString());
            }

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    private void SetUserProperties(User user)
    {
        var email = user.Email;
        user.UserName =  email.Substring(0, email.IndexOf("@"));
        user.FirstName = email.Substring(0, email.IndexOf("."));
        user.LastName =  email.Substring(email.IndexOf("."), email.IndexOf("@"));
        user.PasswordHash = new Password(16).Next();
        user.NormalizedUserName = email.Substring(0, email.IndexOf("@")).ToUpper();
        user.SecurityStamp = Guid.NewGuid().ToString();
        user.EmailConfirmed = true;
        user.PhoneNumberConfirmed = true;
    }
}