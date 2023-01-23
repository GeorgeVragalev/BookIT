using System.Data;
using System.Globalization;
using AutoMapper;
using Backend.Entities.Rooms;
using Backend.Helpers;
using Backend.Models;
using Backend.Models.Sorting;
using Backend.Services.Rooms.RoomService;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

public class RoomController : Controller
{
    private readonly IRoomService _roomService;
    private readonly IMapper _mapper;

    // GET
    public RoomController(IRoomService roomService, IMapper mapper)
    {
        _roomService = roomService;
        _mapper = mapper;
    }

    public IActionResult Rooms()
    {
        return View();
    }

    [HttpPost]
    public Task<JsonResult> GetRoomsList()
    {
        var draw = Request.Form["draw"].FirstOrDefault();
        var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"]
            .FirstOrDefault();
        var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
        var searchValue = Request.Form["search[value]"].FirstOrDefault();
        var pageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "0");
        var skip = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");

        var dbData =  _roomService.GetAll();
        var data = _mapper.Map<IList<RoomModel>>(dbData);

        var totalRecord = data.Count();
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

    private IList<RoomModel> SortDataByColumn(IList<RoomModel> data, string sortColumn, string sortColumnDirection)
    {
        return sortColumn switch
        {
            "Name" => SortName(data, sortColumnDirection),
            "Capacity" => SortCapacity(data, sortColumnDirection),
            _ => data
        };
    }
    private IList<RoomModel> SortName(IList<RoomModel> data, string sortColumnDirection)
    {
        return sortColumnDirection.ToLower() == SortingDirection.asc.ToString()
            ? data.OrderBy(u => u.Name).ToList()
            : data.OrderByDescending(u => u.Name).ToList();
    }
    
    private IList<RoomModel> SortCapacity(IList<RoomModel> data, string sortColumnDirection)
    {
        return sortColumnDirection.ToLower() == SortingDirection.asc.ToString()
            ? data.OrderBy(u => u.Capacity).ToList()
            : data.OrderByDescending(u => u.Capacity).ToList();
    }
    
    private IList<RoomModel> SearchByValue(IList<RoomModel> data, string searchValue)
    {
        return data.Where(x =>
            x.Name.ToLower().Contains(searchValue.ToLower()) ||
            x.Capacity == int.Parse(searchValue, NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite) ||
            x.FacilityString != null && x.FacilityString.Contains(searchValue.ToLower())
        ).ToList();
    }
}