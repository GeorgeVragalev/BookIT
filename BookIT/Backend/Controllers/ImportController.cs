using Backend.Entities.Users;
using Backend.Services.DataImport;
using Backend.Services.DataImport.Strategy;
using Backend.Services.Rooms.RoomService;
using Backend.Services.University.DepartmentService;
using Backend.Services.University.GroupService;
using Backend.Services.University.SubjectService;
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
    private readonly ISubjectService _subjectService;
    private readonly IRoomService _roomService;
    private readonly IGroupService _groupService;
    private readonly IStrategy _departmentImportStrategy;
    private readonly IStrategy _roomImportStrategy;
    private readonly IStrategy _userImportStrategy;
    private readonly IStrategy _subjectImportStrategy;
    private readonly IStrategy _groupImportStrategy;

    public ImportController(ICsvImport csvImport, IUserService userService, UserManager<User> userManager, IDepartmentService departmentService, IRoomService roomService, ISubjectService subjectService, IGroupService groupService)
    {
        _csvImport = csvImport;
        _userService = userService;
        _userManager = userManager;
        _departmentService = departmentService;
        _roomService = roomService;
        _subjectService = subjectService;
        _groupService = groupService;
        _userImportStrategy = new UserImportStrategy(userService, userManager);
        _subjectImportStrategy = new SubjectImportStrategy(subjectService);
        _groupImportStrategy = new GroupImportStrategy(groupService);
        _departmentImportStrategy = new DepartmentImportStrategy(departmentService);
        _roomImportStrategy = new RoomImportStrategy(roomService);
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
        await _csvImport.SetStrategy(_userImportStrategy);

        await ImportData(file);
        
        return RedirectToAction("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Departments(IFormFile file)
    {
        await _csvImport.SetStrategy(_departmentImportStrategy);

        await ImportData(file);
        
        return RedirectToAction("Index");
    }
    
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Rooms(IFormFile file)
    {
        await _csvImport.SetStrategy(_roomImportStrategy);

        await ImportData(file);
        
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Groups(IFormFile file)
    {
        await _csvImport.SetStrategy(_groupImportStrategy);

        await ImportData(file);
        
        return RedirectToAction("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Subjects(IFormFile file)
    {
        await _csvImport.SetStrategy(_subjectImportStrategy);

        await ImportData(file);
        
        return RedirectToAction("Index");
    }
    
    private async Task ImportData(IFormFile file)
    {
        try
        {
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