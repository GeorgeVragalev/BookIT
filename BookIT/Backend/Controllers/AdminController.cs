using System.Text;
using System.Text.Encodings.Web;
using Backend.Entities.Roles;
using Backend.Entities.UniversityEntities;
using Backend.Entities.Users;
using Backend.Models;
using Backend.Services.University.DepartmentService;
using Backend.Services.University.GroupService;
using Backend.Services.University.SubjectService;
using Backend.Services.Users.StudentService;
using Backend.Services.Users.TeacherService;
using Backend.Services.Users.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using PasswordGenerator;

namespace Backend.Controllers;

// [Authorize(Roles = "Administrator")]
[AutoValidateAntiforgeryToken]
public class AdminController : Controller
{
    private readonly RoleManager<Role> _roleManager;
    private readonly UserManager<User> _userManager;
    private readonly IUserService _userService;
    private readonly IEmailSender _emailSender;
    private readonly IStudentService _studentService;
    private readonly ITeacherService _teacherService;
    private readonly IGroupService _groupService;
    private readonly IDepartmentService _departmentService;
    private readonly ISubjectService _subjectService;

    public AdminController(RoleManager<Role> roleManager, IUserService userService, UserManager<User> userManager,
        IEmailSender emailSender, IStudentService studentService, ITeacherService teacherService, IDepartmentService departmentService, 
        IGroupService groupService, ISubjectService subjectService)
    {
        _roleManager = roleManager;
        _userService = userService;
        _userManager = userManager;
        _emailSender = emailSender;
        _studentService = studentService;
        _departmentService = departmentService;
        _groupService = groupService;
        _subjectService = subjectService;
        _teacherService = teacherService;
    }

    [HttpGet]
    public IActionResult CreateUser()
    {
        var userModel = new UserModel
        {
            Role = RoleEnum.Administrator
        };
        return View(userModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateUser(UserModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new User()
            {
                Email = model.Email,
                PasswordHash = new Password(16).Next(),
                SecurityStamp =  Guid.NewGuid().ToString(),
                FirstName = model.Email.Substring(0,  model.Email.IndexOf(".", StringComparison.Ordinal)),
                LastName =  model.Email.Substring(model.Email.IndexOf(".", StringComparison.Ordinal),  model.Email.IndexOf("@", StringComparison.Ordinal))

            };
            
            await _userService.Save(user);

            if (model.Role == RoleEnum.Student)
            {
                var group = _groupService.GetAll().FirstOrDefault();
                var student = new Student()
                {
                    GroupId = group?.Id,
                    Group = group,
                    AboutMe = "dadf",
                    UserId = user.Id,
                    User = user
                };

                await _studentService.Save(student);
                
                // user.Student = student;
                // user.StudentId = student.Id;
            }
            else if (model.Role == RoleEnum.Teacher)
            {
                var dep = _departmentService.GetAll().FirstOrDefault();
                var subjects = _subjectService.GetAll();
                var teacher = new Teacher()
                {
                    Quote = "If you reach it",
                    AboutMe = "Best teacher",
                    UserId = user.Id,
                    DepartmentId = dep?.Id,
                    Department = dep,
                    User = user,
                    Subjects = subjects
                };

                await _teacherService.Save(teacher);
                
                user.Teacher = teacher;
                user.TeacherId = teacher.Id;
            }
            
            await _userService.Update(user);

            //assign role
            await _userManager.AddToRoleAsync(user, model.Role.ToString());
            
            var userId = user.Id;
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new {area = "Identity", userId = userId, code = code, returnUrl = Url.Content("~/")},
                protocol: Request.Scheme);

            await _emailSender.SendEmailAsync(user.Email, "Confirm your email",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            if (_userManager.Options.SignIn.RequireConfirmedAccount)
            {
                return RedirectToPage("/Account/RegisterConfirmation",
                    new {area = "Identity", email = user.Email, returnUrl = Url.Content("~/")});
            }
            else
            {
                return LocalRedirect(Url.Content("~/"));
            }
        }

        return View(model);
    }
}