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
        var lessons = _lessonService.GetAll();

        var events = _mapper.Map<IList<EventModel>>(lessons);

        return new JsonResult(events);
    }
}