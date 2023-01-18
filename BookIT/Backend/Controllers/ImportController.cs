using Backend.Services.DataImport;
using Backend.Services.DataImport.Stategy;
using Backend.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[AutoValidateAntiforgeryToken]
public class ImportController : Controller
{
    private readonly ICsvImport _csvImport;
    private readonly IUserService _userService;

    public ImportController(ICsvImport csvImport, IUserService userService)
    {
        _csvImport = csvImport;
        _userService = userService;
    }

    [HttpGet]
    public IActionResult Users()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Users(IFormFile file)
    {
        try
        {
            _csvImport.SetStrategy(new UserImportStrategy(_userService));
            if (file.Length > 0)
            {
                _csvImport.ImportData(file);

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