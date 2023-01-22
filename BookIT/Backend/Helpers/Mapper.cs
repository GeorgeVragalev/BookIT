using Backend.Entities.Roles;
using Backend.Entities.Rooms;
using Backend.Entities.UniversityEntities;
using Backend.Entities.Users;
using Backend.Models;

namespace Backend.Helpers;

public static class Mapper
{
    private static string PrepareFacilityString(IEnumerable<Facility> roomFacilities)
    {
        return string.Join(", ", roomFacilities.Select(roomFacility => roomFacility.FacilityType.ToString()).ToArray());
    }

    private static string ListToString<T>(this IEnumerable<T> roomFacilities)
    {
        return string.Join(", ", roomFacilities.ToArray());
    }
}