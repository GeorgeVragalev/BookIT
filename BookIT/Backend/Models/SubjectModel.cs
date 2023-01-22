using Backend.Entities.Shared;
using Backend.Entities.Users;

namespace Backend.Models;

public class SubjectModel : IBaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? Laboratories { get; set; }
    public int? Exams { get; set; }
    public int? Hours { get; set; }
    public virtual IList<TeacherModel> Teachers { get; set; }
}