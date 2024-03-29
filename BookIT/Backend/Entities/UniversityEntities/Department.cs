﻿using Backend.Entities.Shared;
using Backend.Entities.Users;

namespace Backend.Entities.UniversityEntities;

public class Department : IBaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual List<Teacher>? Teachers { get; set; }
}