﻿using Backend.Entities.Users;
using Backend.Models.Sorting;
using Backend.Services.UserService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;

// [Authorize(Roles = "Administrator")]
public class UserController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly IUserService _userService;

    public UserController(UserManager<User> userManager, IUserService userService)
    {
        _userManager = userManager;
        _userService = userService;
    }
    
    public async Task<IActionResult> UsersList()
    {
        var users = await _userManager.Users.ToListAsync();

        return View(users);
    }

    //TODO: Move sorting methods to another class (let's discuss)
    [HttpPost]
    public Task<JsonResult> GetUsersList()
    {
        var draw = Request.Form["draw"].FirstOrDefault();
        var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"]
            .FirstOrDefault();
        var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
        var searchValue = Request.Form["search[value]"].FirstOrDefault();
        var pageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "0");
        var skip = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");
        var data = _userService.GetAll();
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

    private IQueryable<User> SearchByValue(IQueryable<User> data, string searchValue)
    {
        //TODO: Remove nullable from First and LastName
        return data.Where(x =>
            x.Email.ToLower().Contains(searchValue.ToLower()) ||
            x.FirstName.ToLower().Contains(searchValue.ToLower()) ||
            x.LastName.ToLower().Contains(searchValue.ToLower()));
    }

    private IQueryable<User> SortDataByColumn(IQueryable<User> data, string sortColumn, string sortColumnDirection)
    {
        return sortColumn switch
        {
            "Email" => SortEmail(data, sortColumnDirection),
            "FirstName" => SortFirstName(data, sortColumnDirection),
            "LastName" => SortLastName(data, sortColumnDirection),
            _ => data
        };
    }

    private IQueryable<User> SortLastName(IQueryable<User> data, string sortColumnDirection)
    {
        return sortColumnDirection.ToLower() == SortingDirection.asc.ToString()
            ? data.OrderBy(u => u.FirstName)
            : data.OrderByDescending(u => u.FirstName);
    }

    private IQueryable<User> SortFirstName(IQueryable<User> data,string sortColumnDirection)
    {
        return sortColumnDirection.ToLower() == SortingDirection.asc.ToString()
            ? data.OrderBy(u => u.FirstName)
            : data.OrderByDescending(u => u.FirstName);
    }

    private IOrderedQueryable<User> SortEmail(IQueryable<User> data, string sortColumnDirection)
    {
        return sortColumnDirection.ToLower() == SortingDirection.asc.ToString()
            ? data.OrderBy(u => u.Email)
            : data.OrderByDescending(u => u.Email);
    }
}