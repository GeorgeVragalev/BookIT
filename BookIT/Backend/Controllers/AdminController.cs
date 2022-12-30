using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

public class AdminController : Controller
{

    public IActionResult Index()
    {
        return View();
    }
}