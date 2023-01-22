using Backend.Entities.Users;
using Backend.Services.DataImport;
using Backend.Services.DataImport.Strategy;
using Backend.Services.Users.UserService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[AutoValidateAntiforgeryToken]
public class ImportController : Controller
{
    private readonly ICsvImport _csvImport;
    private readonly IUserService _userService;
    private readonly UserManager<User> _userManager;

    public ImportController(ICsvImport csvImport, IUserService userService, UserManager<User> userManager)
    {
        _csvImport = csvImport;
        _userService = userService;
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Users()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Users(IFormFile file)
    {
        try
        {
            await _csvImport.SetStrategy(new UserImportStrategy(_userService, _userManager));
            if (file.Length > 0)
            {
                await _csvImport.ImportData(file);

                ViewBag.Message = "File Uploaded Successfully!!";
            }
            return View();
        }
        catch
        {
            ViewBag.Message = "File upload failed!!";
            return View();
        }
    }
}