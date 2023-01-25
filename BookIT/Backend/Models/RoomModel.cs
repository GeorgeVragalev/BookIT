using Backend.Entities.Shared;

namespace Backend.Models;

public class RoomModel : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Capacity { get; set; }

    private bool _isAvailable;

    public bool IsAvailable
    {
        get
        {
            if (Lessons != null /*&& Lessons.Any(l=>l.TimePeriod.StartTime < DateTime.Now &&  DateTime.Now < l.TimePeriod.EndTime)*/)
            {
                return false;
            }

            return true;
        }
        set => _isAvailable = value;
    }

    public virtual IList<FacilityModel>? Facilities { get; set; }
    public IList<LessonModel>? Lessons { get; set; }

    public string? FacilityString { get; set; }
}