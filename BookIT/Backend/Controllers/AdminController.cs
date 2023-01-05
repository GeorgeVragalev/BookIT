using System.Text;
using System.Text.Encodings.Web;
using Backend.Entities.Roles;
using Backend.Entities.Users;
using Backend.Helpers;
using Backend.Models;
using Backend.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using PasswordGenerator;

namespace Backend.Controllers;

[Authorize(Roles = "Administrator")]
public class AdminController : Controller
{
    private readonly RoleManager<Role> _roleManager;
    private readonly UserManager<User> _userManager;
    private readonly IUserService _userService;
    private readonly IEmailSender _emailSender;

    public AdminController(RoleManager<Role> roleManager, IUserService userService, UserManager<User> userManager,
        IEmailSender emailSender)
    {
        _roleManager = roleManager;
        _userService = userService;
        _userManager = userManager;
        _emailSender = emailSender;
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
    public async Task<IActionResult> CreateUser(UserModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new User()
            {
                Email = model.Email,
                PasswordHash = new Password(16).Next(),
                SecurityStamp =  Guid.NewGuid().ToString()
            };

            await _userService.Save(user);

            //assign role
            await _userManager.AddToRoleAsync(user, model.Role.ToString());

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var callbackUrl = UrlHelper.PrepareCallbackUrl(Url, Request, code, "/Account/ConfirmEmail", user.Id);

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