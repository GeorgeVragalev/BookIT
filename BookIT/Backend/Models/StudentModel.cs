using Backend.Entities.Shared;
using Newtonsoft.Json;

namespace Backend.Models;

public class StudentModel : IBaseEntity
{
    public int Id { get; set; }
    public string? AboutMe { get; set; }
    
    [JsonIgnore]
    public virtual UserModel? User { get; set; }
    [JsonIgnore]
    public virtual GroupModel? Group { get; set; }
}