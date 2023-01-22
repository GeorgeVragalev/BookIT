using AutoMapper;
using Backend.Entities.Rooms;
using Backend.Entities.UniversityEntities;
using Backend.Helpers;
using Backend.Models;
using Backend.Services.Rooms.RoomService;
using Backend.Services.University.DepartmentService;
using CsvHelper;

namespace Backend.Services.DataImport.Strategy;

public class RoomImportStrategy : IStrategy
{
    private readonly IRoomService _roomService;

    public RoomImportStrategy(IRoomService roomService)
    {
        _roomService = roomService;
    }

    public async Task<bool> Import(IMapper mapper, CsvReader csvReader)
    {
        try
        {
            var roomModels = csvReader.GetRecords<RoomModel>().ToList();

            foreach (var model in roomModels)
            {
                var room = mapper.Map<Room>(model);
                await _roomService.Save(room);
            }

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}