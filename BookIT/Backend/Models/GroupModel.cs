using System.Text.Json.Serialization;
using Backend.Entities.Shared;

namespace Backend.Models;

public class GroupModel : IBaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    [JsonIgnore]
    public virtual IList<StudentModel>? Students { get; set; }
    [JsonIgnore]
    public virtual IList<LessonModel>? Lessons { get; set; }
}