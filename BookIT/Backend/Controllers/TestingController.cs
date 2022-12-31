using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

public class TestingController : Controller
{
    [Authorize(Roles = "Administrator")]
    public ActionResult Restricted()
    {
        return View();
    }
}