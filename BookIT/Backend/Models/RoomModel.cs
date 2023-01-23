using Backend.Entities.Shared;

namespace Backend.Models;

public class RoomModel: IBaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Capacity { get; set; }
    
    public IList<FacilityModel>? Facilities { get; set; }
    public virtual IList<LessonModel>? Lessons { get; set; }

    public string? FacilityString { get; set; }
}