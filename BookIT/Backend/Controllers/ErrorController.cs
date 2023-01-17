using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

public class ErrorController : Controller
{
    public ActionResult Error()
    {
        return View();
    }
}