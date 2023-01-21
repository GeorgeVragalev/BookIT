﻿using Backend.Entities.Shared;
using Backend.Entities.UniversityEntities;

namespace Backend.Entities.Users;

public class Teacher : IBaseEntity
{
    public int Id { get; set; }
    public string AboutMe { get; set; }
    public string Quote { get; set; }

    public int DepartmentId { get; set; }
    public Department Department { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; }
    
    public IList<TeacherSubject>? TeacherSubjects { get; set; }
}