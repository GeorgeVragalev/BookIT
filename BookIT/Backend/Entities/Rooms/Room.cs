using Backend.Entities.LessonEntities;
using Backend.Entities.Shared;

namespace Backend.Entities.Rooms;

public class Room : IBaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Capacity { get; set; }
    
    public virtual IList<Facility>? Facilities { get; set; }
    public virtual IList<Lesson>? Lessons { get; set; }
}