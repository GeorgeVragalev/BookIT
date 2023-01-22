using Backend.Entities.Rooms;
using Backend.Entities.Shared;

namespace Backend.Models;

public class FacilityModel : IBaseEntity
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public FacilityType FacilityType { get; set; }
}