using Backend.Entities.Rooms;
using Backend.Helpers;
using Backend.Models;
using Backend.Services.Rooms.RoomService;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

public class RoomController : Controller
{
    private readonly IRoomService _roomService;
    // GET
    public RoomController(IRoomService roomService)
    {
        _roomService = roomService;
    }

    public IActionResult Rooms()
    {
        var rooms = List();

        return View(rooms);
    }

    private IList<RoomModel> List()
    {
        var newRoom = new Room()
        {
            Capacity = 10,
            Id = 1,
            Name = "303",
            Facilities = new List<Facility>()
        };

        var fac1 = new Facility()
        {
            Id = 1,
            Quantity = 2,
            Room = newRoom,
            RoomId = 1,
            FacilityType = FacilityType.Projector
        };

        newRoom.Facilities.Add(fac1);

        var rooms = new List<RoomModel>()
        {
            newRoom.ToModel()
        };
        // var rooms = _roomService.GetAll();

        return rooms;
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

        var data = List();
        //get total count of data in table
        var totalRecord = data.Count();
        /*// search data when search value found
        if (!string.IsNullOrEmpty(searchValue))
        {
            data = SearchByValue(data, searchValue);
        }*/

        var filterRecord = data.Count();

        /*if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortColumnDirection))
        {
            data = SortDataByColumn(data, sortColumn, sortColumnDirection);
        }*/

        //pagination
        var empList = data.Skip(skip).Take(pageSize).ToList();
        var returnObj = new
        {
            draw = draw, recordsTotal = totalRecord, recordsFiltered = filterRecord, data = empList
        };
        
        return Task.FromResult(new JsonResult(returnObj));
    }

}