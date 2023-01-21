namespace Backend.Models;

public class RoomModel
{
    public RoomModel()
    {
        Facilities = new List<FacilityModel>();
    }
    public string Name { get; set; }
    public int Capacity { get; set; }
    public IList<FacilityModel> Facilities { get; set; }
}