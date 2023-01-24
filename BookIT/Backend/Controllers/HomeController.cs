using System.Diagnostics;
using AutoMapper;
using Backend.Entities.LessonEntities;
using Backend.Entities.Shared;
using Backend.Models;
using Backend.Services.University.LessonService;
using Backend.Services.Users.UserService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Backend.Controllers;

[AutoValidateAntiforgeryToken]
public class HomeController : Controller
{
    private readonly ILessonService _lessonService;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public HomeController(ILessonService lessonService, IMapper mapper, IUserService userService)
    {
        _lessonService = lessonService;
        _mapper = mapper;
        _userService = userService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> GetCurrentUser()
    {
        var userEmail = User.Identity?.Name;
        if (!string.IsNullOrEmpty(userEmail))
        {
            var user = await _userService.GetByEmail(userEmail);

            Lesson? currentLesson = null;
            if (user != null)
            {
                if (user.Student != null)
                {
                    if (user.Student.Group != null && user.Student.Group.Lessons != null && user.Student.Group.Lessons.Count != 0)
                    {
                        currentLesson = user.Student.Group.Lessons.FirstOrDefault(l => l.TimePeriod.StartTime > DateTime.Now && DateTime.Now < l.TimePeriod.EndTime);
                    }
                }
                else if (user.Teacher != null)
                {
                    if (user.Teacher.Lessons != null && user.Teacher.Lessons.Count != 0)
                    {
                        currentLesson = user.Teacher.Lessons.FirstOrDefault(l => l.TimePeriod.StartTime > DateTime.Now && DateTime.Now < l.TimePeriod.EndTime);
                    }
                }
            }

            if (currentLesson != null)
            {
                return Json(new { 
                    agenda = currentLesson.Name,
                    subject = currentLesson.Subject?.Name,
                    groupName = currentLesson.Group?.Name,
                    teacher = currentLesson.Teacher?.User?.GetFullName(),
                    room = currentLesson.GetLessonLocation()
                });
            }
        }
        return Json(null);
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }

    [Route("findall")]
    public IActionResult FindAllEvents()
    {
        var lessons = _lessonService.GetAll();

        var events = _mapper.Map<IList<EventModel>>(lessons);

        return new JsonResult(events);
    }
}