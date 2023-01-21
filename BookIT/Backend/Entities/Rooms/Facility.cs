using Backend.Entities.Shared;

namespace Backend.Entities.Rooms;

public class Facility : IBaseEntity
{
    public int Id { get; set; }

    public FacilityType FacilityType { get; set; }
    public int Quantity { get; set; }
    public int RoomId { get; set; }
    public Room Room { get; set; }
}