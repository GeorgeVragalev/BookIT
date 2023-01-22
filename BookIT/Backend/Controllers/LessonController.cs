using System.Globalization;
using AutoMapper;
using Backend.Models;
using Backend.Models.Sorting;
using Backend.Services.University.LessonService;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

public class LessonController : Controller
{
    private readonly IMapper _mapper;
    private readonly ILessonService _lessonService;

    public LessonController(IMapper mapper, ILessonService lessonService)
    {
        _mapper = mapper;
        _lessonService = lessonService;
    }

    public IActionResult Lessons()
    {
        return View();
    }

    [HttpPost]
    public Task<JsonResult> GetLessonsList()
    {
        var draw = Request.Form["draw"].FirstOrDefault();
        var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"]
            .FirstOrDefault();
        var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
        var searchValue = Request.Form["search[value]"].FirstOrDefault();
        var pageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "0");
        var skip = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");

        var dbData = _lessonService.GetAll();
        var data = _mapper.Map<IList<LessonModel>>(dbData);

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

    private IList<LessonModel> SortDataByColumn(IList<LessonModel> data, string sortColumn, string sortColumnDirection)
    {
        return sortColumn switch
        {
            "Name" => SortName(data, sortColumnDirection),
            _ => data
        };
    }

    private IList<LessonModel> SortName(IList<LessonModel> data, string sortColumnDirection)
    {
        return sortColumnDirection.ToLower() == SortingDirection.asc.ToString()
            ? data.OrderBy(u => u.Name).ToList()
            : data.OrderByDescending(u => u.Name).ToList();
    }

    private IList<LessonModel> SortStartTime(IList<LessonModel> data, string sortColumnDirection)
    {
        return sortColumnDirection.ToLower() == SortingDirection.asc.ToString()
            ? data.OrderBy(u => u.TimePeriod.StartTime).ToList()
            : data.OrderByDescending(u => u.TimePeriod.StartTime).ToList();
    }

    private IList<LessonModel> SearchByValue(IList<LessonModel> data, string searchValue)
    {
        return data.Where(x =>
            x.Name.ToLower().Contains(searchValue.ToLower()) /* ||
            x.Capacity == int.Parse(searchValue, NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite) ||
            x.FacilityString != null && x.FacilityString.Contains(searchValue.ToLower())*/
        ).ToList();
    }
}