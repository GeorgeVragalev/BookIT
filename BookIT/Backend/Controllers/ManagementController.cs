using AutoMapper;
using Backend.Entities.Roles;
using Backend.Entities.Users;
using Backend.Models;
using Backend.Models.Sorting;
using Backend.Services.University.DepartmentService;
using Backend.Services.University.GroupService;
using Backend.Services.University.SubjectService;
using Backend.Services.Users.StudentService;
using Backend.Services.Users.TeacherService;
using Backend.Services.Users.UserService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

public class ManagementController : Controller
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
    private readonly IMapper _mapper;

    public ManagementController(RoleManager<Role> roleManager, UserManager<User> userManager, IUserService userService,
        IEmailSender emailSender, IStudentService studentService, ITeacherService teacherService,
        IGroupService groupService, IDepartmentService departmentService, ISubjectService subjectService,
        IMapper mapper)
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _userService = userService;
        _emailSender = emailSender;
        _studentService = studentService;
        _teacherService = teacherService;
        _groupService = groupService;
        _departmentService = departmentService;
        _subjectService = subjectService;
        _mapper = mapper;
    }

    #region User

    public IActionResult UserList()
    {
        // var dbData = _userService.GetAll();
        // var data = _mapper.Map<IList<UserModel>>(dbData);
        return View();
    }

    [HttpPost]
    public Task<JsonResult> LoadUserList()
    {
        var draw = Request.Form["draw"].FirstOrDefault();
        var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"]
            .FirstOrDefault();
        var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
        var searchValue = Request.Form["search[value]"].FirstOrDefault();
        var pageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "0");
        var skip = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");
        var data = GetUserModelList();

        //get total count of data in table
        var totalRecord = data.Count();
        // search data when search value found
        if (!string.IsNullOrEmpty(searchValue))
        {
            data = SearchByValue(data, searchValue);
        }

        var filterRecord = data.Count();

        if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortColumnDirection))
        {
            data = SortDataByColumn(data, sortColumn, sortColumnDirection);
        }

        //pagination
        var empList = data.Skip(skip).Take(pageSize).ToList();
        var returnObj = new
        {
            draw = draw, recordsTotal = totalRecord, recordsFiltered = filterRecord, data = empList
        };
        return Task.FromResult(new JsonResult(returnObj));
    }

    [HttpPost]
    public Task<JsonResult> GetEditUrl(int id)
    {
        return Task.FromResult(Json(new {url = Url.Action("EditUser", new {id = id})}));
    }
    
    [HttpGet]
    public Task<JsonResult> GetCreateUserLink()
    {
        return Task.FromResult(Json(new {url = Url.Action("CreateUser")}));
    }
    
    [HttpGet("management/edituser/{id:int}")]
    public async Task<IActionResult> EditUser(int id)
    {
        var user = await _userService.GetById(id);

        if (user == null)
        {
            return View("UserList");
        }

        var model = _mapper.Map<UserModel>(user);
        return View(model);
    }
    
    [HttpGet]
    public IActionResult CreateUser()
    {
        return View();
    }
    
    [HttpPost]
    public async Task UpdateUser(UserModel userModel)
    {
        var user = _mapper.Map<User>(userModel);
        await _userService.Update(user);
        RedirectToAction("UserList");
    }

    [HttpDelete]
    public async Task<RedirectToActionResult> DeleteUser(int id)
    {
        var user = await _userService.GetById(id);
        if (user == null)
        {
            return RedirectToAction("UserList");
        }

        await _userService.Delete(user);
        return RedirectToAction("UserList");
    }

    private IList<UserModel> GetUserModelList()
    {
        var dbData = _userService.GetAll();
        return _mapper.Map<IList<UserModel>>(dbData);
    }

    private IList<UserModel> SearchByValue(IList<UserModel> data, string searchValue)
    {
        //TODO: Remove nullable from First and LastName
        return data.Where(x =>
            x.Email.ToLower().Contains(searchValue.ToLower()) ||
            x.FirstName.ToLower().Contains(searchValue.ToLower()) ||
            x.LastName.ToLower().Contains(searchValue.ToLower())).ToList();
    }

    private IList<UserModel> SortDataByColumn(IList<UserModel> data, string sortColumn, string sortColumnDirection)
    {
        return sortColumn switch
        {
            "Email" => SortEmail(data, sortColumnDirection),
            "FirstName" => SortFirstName(data, sortColumnDirection),
            "LastName" => SortLastName(data, sortColumnDirection),
            _ => data
        };
    }

    private IList<UserModel> SortLastName(IList<UserModel> data, string sortColumnDirection)
    {
        return sortColumnDirection.ToLower() == SortingDirection.asc.ToString()
            ? data.OrderBy(u => u.FirstName).ToList()
            : data.OrderByDescending(u => u.FirstName).ToList();
    }

    private IList<UserModel> SortFirstName(IList<UserModel> data, string sortColumnDirection)
    {
        return sortColumnDirection.ToLower() == SortingDirection.asc.ToString()
            ? data.OrderBy(u => u.FirstName).ToList()
            : data.OrderByDescending(u => u.FirstName).ToList();
    }

    private IList<UserModel> SortEmail(IList<UserModel> data, string sortColumnDirection)
    {
        return sortColumnDirection.ToLower() == SortingDirection.asc.ToString()
            ? data.OrderBy(u => u.Email).ToList()
            : data.OrderByDescending(u => u.Email).ToList();
    }

    #endregion

    
}