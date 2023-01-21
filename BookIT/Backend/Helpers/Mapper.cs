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
            Facilities = room.Facilities.Select(f => f.ToModel()).ToList()
        };
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