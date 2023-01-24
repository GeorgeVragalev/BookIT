using AutoMapper;
using Backend.Entities.Roles;
using Backend.Entities.Users;
using Backend.Helpers;
using Backend.Models;
using Backend.Services.Users.StudentService;
using Backend.Services.Users.TeacherService;
using Backend.Services.Users.UserService;
using CsvHelper;
using Microsoft.AspNetCore.Identity;
using PasswordGenerator;

namespace Backend.Services.DataImport.Strategy;

public class UserImportStrategy : IStrategy
{
    private readonly IUserService _userService;
    private readonly UserManager<User> _userManager;
    private readonly ITeacherService _teacherService;
    private readonly IStudentService _studentService;

    public UserImportStrategy(IUserService userService, UserManager<User> userManager, ITeacherService teacherService, IStudentService studentService)
    {
        _userService = userService;
        _userManager = userManager;
        _teacherService = teacherService;
        _studentService = studentService;
    }

    public async Task<bool> Import(IMapper mapper, CsvReader csvReader)
    {
        try
        {
            var userModels = csvReader.GetRecords<UserModel>().ToList();

            foreach (var model in userModels)
            {
                var user = mapper.Map<User>(model);
                SetUserProperties(user);
                await _userService.Save(user);
                
                if (model.Role == RoleEnum.Student)
                {
                    var student = new Student()
                    {
                        User = user,
                        UserId = user.Id
                    };
                    await _studentService.Save(student);
                }
                else if (model.Role == RoleEnum.Teacher)
                {
                    var teacher = new Teacher()
                    {
                        User = user,
                        UserId = user.Id
                    };
                    await _teacherService.Save(teacher);
                }
                
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
        user.UserName = email.Substring(0, email.IndexOf("@", StringComparison.Ordinal));
        user.FirstName = email.Substring(0, email.IndexOf(".", StringComparison.Ordinal));
        user.LastName = email.Substring(email.IndexOf(".", StringComparison.Ordinal), email.IndexOf("@", StringComparison.Ordinal));
        user.PasswordHash = new Password(16).Next();
        user.NormalizedUserName = email.Substring(0, email.IndexOf("@", StringComparison.Ordinal)).ToUpper();
        user.SecurityStamp = Guid.NewGuid().ToString();
        user.EmailConfirmed = true;
        user.PhoneNumberConfirmed = true;
    }
}