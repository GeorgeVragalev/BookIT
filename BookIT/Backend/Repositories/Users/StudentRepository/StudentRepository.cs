﻿using Backend.Entities.Users;
using Backend.Repositories.GenericRepository;

namespace Backend.Repositories.Users.StudentRepository;

public class StudentRepository : IStudentRepository
{
    private readonly IGenericRepository<Student> _repository;

    public StudentRepository(IGenericRepository<Student> repository)
    {
        _repository = repository;
    }

    public IQueryable<Student> GetAll()
    {
        return _repository.GetAll();
    }

    public Task<Student?> GetById(int id)
    {
        return _repository.GetById(id);
    }

    public Task Save(Student student)
    {
        return _repository.Save(student);
    }

    public Task Update(Student student)
    {
        return _repository.Update(student);
    }

    public Task Delete(Student student)
    {
        return _repository.Delete(student);
    }
}