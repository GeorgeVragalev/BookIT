using Backend.Entities.Users;
using Backend.Services.DataImport;
using Backend.Services.DataImport.Strategy;
using Backend.Services.University.DepartmentService;
using Backend.Services.Users.UserService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[AutoValidateAntiforgeryToken]
public class ImportController : Controller
{
    private readonly ICsvImport _csvImport;
    private readonly UserManager<User> _userManager;
    private readonly IUserService _userService;
    private readonly IDepartmentService _departmentService;

    public ImportController(ICsvImport csvImport, IUserService userService, UserManager<User> userManager, IDepartmentService departmentService)
    {
        _csvImport = csvImport;
        _userService = userService;
        _userManager = userManager;
        _departmentService = departmentService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Users(IFormFile file)
    {
        await _csvImport.SetStrategy(new UserImportStrategy(_userService, _userManager));

        await ImportData(file);
        
        return RedirectToAction("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Departments(IFormFile file)
    {
        await _csvImport.SetStrategy(new DepartmentImportStrategy(_departmentService));

        await ImportData(file);
        
        return RedirectToAction("Index");
    }

    private async Task ImportData(IFormFile file)
    {
        try
        {
            await _csvImport.SetStrategy(new UserImportStrategy(_userService, _userManager));
            if (file.Length > 0)
            {
                await _csvImport.ImportData(file);

                ViewBag.Message = "File Uploaded Successfully!!";
            }
        }
        catch
        {
            ViewBag.Message = "File upload failed!!";
        }
    }
}