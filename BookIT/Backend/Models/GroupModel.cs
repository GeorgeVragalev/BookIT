using Backend.Entities.Shared;

namespace Backend.Models;

public class GroupModel : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public virtual IList<StudentModel>? Students { get; set; }
    public IList<LessonModel>? Lessons { get; set; }
}