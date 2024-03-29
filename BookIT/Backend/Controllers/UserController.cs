﻿using AutoMapper;
using Backend.Entities.Users;
using Backend.Helpers;
using Backend.Models;
using Backend.Models.Sorting;
using Backend.Services.Users.UserService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;

// [Authorize(Roles = "Administrator")]
public class UserController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(UserManager<User> userManager, IUserService userService, IMapper mapper)
    {
        _userManager = userManager;
        _userService = userService;
        _mapper = mapper;
    }
    
    public Task<IActionResult> UsersList()
    {
        return Task.FromResult<IActionResult>(View());
    }

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
        var dbData = _userService.GetAll();
        var data = _mapper.Map<IList<UserModel>>(dbData);
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

    private IList<UserModel> SortFirstName(IList<UserModel> data,string sortColumnDirection)
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
}