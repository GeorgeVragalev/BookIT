using AutoMapper;
using Backend.Entities.LessonEntities;
using Backend.Entities.Roles;
using Backend.Entities.Users;
using Backend.Models;
using Backend.Models.Sorting;
using Backend.Services.University.LessonService;
using Backend.Services.Users.UserService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

public class ManagementController : Controller
{
    private readonly RoleManager<Role> _roleManager;
    private readonly UserManager<User> _userManager;
    private readonly IUserService _userService;
    private readonly ILessonService _lessonService;
    private readonly IMapper _mapper;

    public ManagementController(RoleManager<Role> roleManager,
        UserManager<User> userManager,
        IUserService userService,
        IMapper mapper, ILessonService lessonService)
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _userService = userService;
        _mapper = mapper;
        _lessonService = lessonService;
    }

    #region User

    public IActionResult UserList()
    {
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
            data = SearchUserByValue(data, searchValue);
        }

        var filterRecord = data.Count();

        if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortColumnDirection))
        {
            data = SortUserDataByColumn(data, sortColumn, sortColumnDirection);
        }

        //pagination
        var empList = data.Skip(skip).Take(pageSize).ToList();
        var returnObj = new
        {
            draw = draw, recordsTotal = totalRecord, recordsFiltered = filterRecord, data = empList
        };
        return Task.FromResult(new JsonResult(returnObj));
    }

    [HttpGet("management/createuser")]
    public IActionResult CreateUser()
    {
        return View(new UserModel());
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
        TempData["EditMessage"] = "Record edited very successfully";
        return View(model);
    }

    [HttpPost]
    public async Task<RedirectToActionResult> UpdateUser(UserModel userModel)
    {
        var dbUser = await _userService.GetById(userModel.Id);

        _mapper.Map<UserModel, User>(userModel, dbUser);

        await _userService.Update(dbUser);
        return RedirectToAction("UserList");
    }

    public async Task<RedirectToActionResult> DeleteUser(int id)
    {
        var user = await _userService.GetById(id);
        if (user == null)
        {
            return RedirectToAction("UserList");
        }

        await _userService.Delete(user);
        TempData["DeletedMessage"] = "Record deleted very successfully";
        return RedirectToAction("UserList");
    }

    private IList<UserModel> GetUserModelList()
    {
        var dbData = _userService.GetAll();
        return _mapper.Map<IList<UserModel>>(dbData);
    }

    private IList<UserModel> SearchUserByValue(IList<UserModel> data, string searchValue)
    {
        return data.Where(x =>
            x.Email.ToLower().Contains(searchValue.ToLower()) ||
            x.FirstName != null && x.FirstName.ToLower().Contains(searchValue.ToLower()) ||
            x.LastName != null && x.LastName.ToLower().Contains(searchValue.ToLower())).ToList();
    }

    private static IList<UserModel> SortUserDataByColumn(IList<UserModel> data, string sortColumn, string sortColumnDirection)
    {
        return sortColumn switch
        {
            "Email" => SortEmail(data, sortColumnDirection),
            "FirstName" => SortFirstName(data, sortColumnDirection),
            "LastName" => SortLastName(data, sortColumnDirection),
            _ => data
        };
    }

    private static IList<UserModel> SortLastName(IList<UserModel> data, string sortColumnDirection)
    {
        return sortColumnDirection.ToLower() == SortingDirection.asc.ToString()
            ? data.OrderBy(u => u.FirstName).ToList()
            : data.OrderByDescending(u => u.FirstName).ToList();
    }

    private static IList<UserModel> SortFirstName(IList<UserModel> data, string sortColumnDirection)
    {
        return sortColumnDirection.ToLower() == SortingDirection.asc.ToString()
            ? data.OrderBy(u => u.FirstName).ToList()
            : data.OrderByDescending(u => u.FirstName).ToList();
    }

    private static IList<UserModel> SortEmail(IList<UserModel> data, string sortColumnDirection)
    {
        return sortColumnDirection.ToLower() == SortingDirection.asc.ToString()
            ? data.OrderBy(u => u.Email).ToList()
            : data.OrderByDescending(u => u.Email).ToList();
    }

    #endregion


    #region Lesson

    public IActionResult LessonList()
    {
        return View();
    }

    [HttpPost]
    public Task<JsonResult> LoadLessonList()
    {
        var draw = Request.Form["draw"].FirstOrDefault();
        var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"]
            .FirstOrDefault();
        var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
        var searchValue = Request.Form["search[value]"].FirstOrDefault();
        var pageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "0");
        var skip = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");
        var data = GetLessonModelList();

        //get total count of data in table
        var totalRecord = data.Count;
        // search data when search value found
        if (!string.IsNullOrEmpty(searchValue))
        {
            data = SearchLessonByValue(data, searchValue);
        }

        var filterRecord = data.Count;

        if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortColumnDirection))
        {
            data = SortLessonDataByColumn(data, sortColumn, sortColumnDirection);
        }

        //pagination
        var empList = data.Skip(skip).Take(pageSize).ToList();
        var returnObj = new
        {
            draw = draw, recordsTotal = totalRecord, recordsFiltered = filterRecord, data = empList
        };
        return Task.FromResult(new JsonResult(returnObj));
    }

    private IList<LessonModel> GetLessonModelList()
    {
        var dbData = _lessonService.GetAll();
        return _mapper.Map<IList<LessonModel>>(dbData);
    }

    private IList<LessonModel> SearchLessonByValue(IList<LessonModel> data, string searchValue)
    {
        return data.Where(x =>
            x.Name != null && x.Name.ToLower().Contains(searchValue.ToLower()) ||
            x.Room != null && x.Room.Name.ToLower().Contains(searchValue.ToLower()) ||
            x.Room != null && x.Room.Capacity == int.Parse(searchValue) ||
            x.Room != null && x.Room.FacilityString != null &&
            x.Room.FacilityString.Contains(searchValue.ToLower().ToLower())
        ).ToList();
    }

    private IList<LessonModel> SortLessonDataByColumn(IList<LessonModel> data, string sortColumn,
        string sortColumnDirection)
    {
        return sortColumn switch
        {
            "Name" => SortLessonName(data, sortColumnDirection),
            "Group" => SortLessonGroup(data, sortColumnDirection),
            "Subject" => SortLessonSubject(data, sortColumnDirection),
            "Start" => SortLessonStart(data, sortColumnDirection),
            "End" => SortLessonEnd(data, sortColumnDirection),
            _ => data
        };
    }

    private static IList<LessonModel> SortLessonName(IList<LessonModel> data, string sortColumnDirection)
    {
        return sortColumnDirection.ToLower() == SortingDirection.asc.ToString()
            ? data.OrderBy(u => u.Name).ToList()
            : data.OrderByDescending(u => u.Name).ToList();
    }

    private static IList<LessonModel> SortLessonGroup(IList<LessonModel> data, string sortColumnDirection)
    {
        return sortColumnDirection.ToLower() == SortingDirection.asc.ToString()
            ? data.OrderBy(u => u.Group).ToList()
            : data.OrderByDescending(u => u.Group).ToList();
    }

    private static IList<LessonModel> SortLessonSubject(IList<LessonModel> data, string sortColumnDirection)
    {
        return sortColumnDirection.ToLower() == SortingDirection.asc.ToString()
            ? data.OrderBy(u => u.Subject).ToList()
            : data.OrderByDescending(u => u.Subject).ToList();
    }

    private static IList<LessonModel> SortLessonStart(IList<LessonModel> data, string sortColumnDirection)
    {
        return sortColumnDirection.ToLower() == SortingDirection.asc.ToString()
            ? data.OrderBy(u => u.TimePeriod.StartTime).ToList()
            : data.OrderByDescending(u => u.TimePeriod.StartTime).ToList();
    }

    private static IList<LessonModel> SortLessonEnd(IList<LessonModel> data, string sortColumnDirection)
    {
        return sortColumnDirection.ToLower() == SortingDirection.asc.ToString()
            ? data.OrderBy(u => u.TimePeriod.EndTime).ToList()
            : data.OrderByDescending(u => u.TimePeriod.EndTime).ToList();
    }

    [HttpGet("management/createlesson")]
    public IActionResult CreateLesson()
    {
        return View(new LessonModel());
    }

    [HttpGet("management/editlesson/{id:int}")]
    public async Task<IActionResult> EditLesson(int id)
    {
        var lesson = await _lessonService.GetById(id);

        if (lesson == null)
        {
            return View("LessonList");
        }

        var model = _mapper.Map<LessonModel>(lesson);
        TempData["EditMessage"] = "Record edited very successfully";
        return View(model);
    }

    [HttpPost]
    public async Task<RedirectToActionResult> UpdateLesson(LessonModel lesson)
    {
        var dbLesson = await _lessonService.GetById(lesson.Id);

        if (dbLesson == null) return RedirectToAction("UserList");
        _mapper.Map<LessonModel, Lesson>(lesson, dbLesson);

        await _lessonService.Update(dbLesson);

        return RedirectToAction("LessonList");
    }

    public async Task<RedirectToActionResult> DeleteLesson(int id)
    {
        var lesson = await _lessonService.GetById(id);
        if (lesson == null)
        {
            return RedirectToAction("LessonList");
        }

        await _lessonService.Delete(lesson);
        TempData["DeletedMessage"] = "Record deleted very successfully";
        return RedirectToAction("LessonList");
    }

    #endregion
}