using Backend.Entities.Rooms;
using Backend.Entities.Users;
using Backend.Models;

namespace Backend.Helpers;

public static class Mapper
{
    public static User ToEntity(this UserModel model)
    {
        return new User()
        {
            Email = model.Email,
            NormalizedEmail = model.Email.ToUpper()
        };
    }
    
    public static RoomModel ToModel(this Room room)
    {
        return new RoomModel()
        {
            Capacity = room.Capacity,
            Name = room.Name,
            Facilities = room.Facilities.Select(f => f.ToModel()).ToList(),
            FacilityString = PrepareFacilityString(room.Facilities)
        };
    }

    public static IList<RoomModel> ToModel(this IList<Room> models)
    {
        return models.Select(room => room.ToModel()).ToList();
    }
    private static string PrepareFacilityString(IEnumerable<Facility> roomFacilities)
    {
        return string.Join(", ", roomFacilities.Select(roomFacility => roomFacility.FacilityType.ToString()).ToArray());
    }

    public static FacilityModel ToModel(this Facility facility)
    {
        return new FacilityModel()
        {
            Quantity = facility.Quantity,
            FacilityType = facility.FacilityType
        };
    }
}