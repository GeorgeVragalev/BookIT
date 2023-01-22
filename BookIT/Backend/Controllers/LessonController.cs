using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

public class LessonController : Controller
{
    // public IActionResult Timetable()
    // {
    //     return View();
    // }
    //
    // [HttpPost]
    // public Task<JsonResult> GetRoomsList()
    // {
    //     var draw = Request.Form["draw"].FirstOrDefault();
    //     var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"]
    //         .FirstOrDefault();
    //     var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
    //     var searchValue = Request.Form["search[value]"].FirstOrDefault();
    //     var pageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "0");
    //     var skip = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");
    //
    //     var dbData =  _roomService.GetAll();
    //     var data = _mapper.Map<IList<TimetableModel>>(dbData);
    //
    //     var totalRecord = data.Count();
    //     if (!string.IsNullOrEmpty(searchValue))
    //     {
    //         data = SearchByValue(data, searchValue);
    //     }
    //
    //     var filterRecord = data.Count();
    //
    //     if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortColumnDirection))
    //     {
    //         data = SortDataByColumn(data, sortColumn, sortColumnDirection);
    //     }
    //
    //     //pagination
    //     var empList = data.Skip(skip).Take(pageSize).ToList();
    //     var returnObj = new
    //     {
    //         draw = draw, recordsTotal = totalRecord, recordsFiltered = filterRecord, data = empList
    //     };
    //
    //     return Task.FromResult(new JsonResult(returnObj));
    // }
    // private IList<TimetableModel> SearchByValue(IList<TimetableModel> data, string searchValue)
    // {
    //     return data.Where(x =>
    //         x.Name.ToLower().Contains(searchValue.ToLower()) ||
    //         x.Capacity == int.Parse(searchValue, NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite) ||
    //         x.FacilityString != null && x.FacilityString.Contains(searchValue.ToLower())
    //     ).ToList();
    // }
    // private IList<TimetableModel> SortDataByColumn(IList<TimetableModel> data, string sortColumn, string sortColumnDirection)
    // {
    //     return sortColumn switch
    //     {
    //         "Name" => SortName(data, sortColumnDirection),
    //         "Capacity" => SortCapacity(data, sortColumnDirection),
    //         _ => data
    //     };
    // }
}