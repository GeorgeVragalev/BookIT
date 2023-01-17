using Backend.Entities.Users;
using Backend.Helpers;
using Backend.Models;
using Backend.Services.UserService;
using CsvHelper;
using PasswordGenerator;

namespace Backend.Services.DataImport.Stategy;

public class UserImportStrategy : IStrategy
{
    private readonly IUserService _userService;

    public UserImportStrategy(IUserService userService)
    {
        _userService = userService;
    }

    public bool Import(CsvReader csvReader)
    {
        try
        {
            if (!IsCsvValid(csvReader))
            {
                return false;
            }

            var userModels = csvReader.GetRecords<UserModel>();
            foreach (var model in userModels)
            {
                var user = model.ToEntity();
                SetUserProperties(user);
                _userService.Save(user);
            }

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public bool IsCsvValid(CsvReader csvReader)
    {
        try
        {
            var userModels = csvReader.GetRecords<UserModel>();
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
        user.UserName = user.Email.Substring(0, email.IndexOf("@"));
        user.FirstName = user.Email.Substring(0, email.IndexOf("."));
        user.LastName = user.Email.Substring(email.IndexOf("."), email.IndexOf("@"));
        user.PasswordHash = new Password(16).Next();
        user.SecurityStamp = Guid.NewGuid().ToString();
        user.EmailConfirmed = true;
    }
}