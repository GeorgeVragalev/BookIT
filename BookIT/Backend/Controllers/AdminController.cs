using Backend.Entities.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

public class AdminController : Controller
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public AdminController(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(Role model)
    {
        if (ModelState.IsValid)
        {
            var identityRole = new IdentityRole()
            {
                Name = model.Name
            };

            var result = await _roleManager.CreateAsync(identityRole);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            foreach (var identityError in result.Errors)
            {
                ModelState.AddModelError("", identityError.Description);
            }
        }
        return View(model);
    }
}