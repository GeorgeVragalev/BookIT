using System.Diagnostics;
using AutoMapper;
using Backend.Entities.Shared;
using Backend.Models;
using Backend.Services.University.LessonService;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[AutoValidateAntiforgeryToken]
public class HomeController : Controller
{
    private readonly ILessonService _lessonService;
    private readonly IMapper _mapper;

    public HomeController(ILessonService lessonService, IMapper mapper)
    {
        _lessonService = lessonService;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        var lessons = _lessonService.GetAll();
        ViewData["Events"] = _mapper.Map<IList<EventModel>>(lessons);
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
    
    [Route("findall")]
    public IActionResult FindAllEvents()
    {
        var lessons = _lessonService.GetAll().Select(e => new
        {
            id = e.Id,
            title = e.Name,
            start = e.TimePeriod.StartTime.ToString("d") +" "+ e.TimePeriod.StartTime.ToString("t"),
            end = e.TimePeriod.EndTime.ToString("d") +" "+ e.TimePeriod.EndTime.ToString("t"),
            group = e.Group?.Name,
            teacher = e.Teacher?.User?.GetFullName()
        });
        return new JsonResult(lessons);
    }

}