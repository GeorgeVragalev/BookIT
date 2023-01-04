﻿using Backend.Entities.Users;
using Backend.Repositories.GenericRepository;

namespace Backend.Repositories.UserRepository;

public interface IUserRepository : IGenericRepository<User>
{
    
}