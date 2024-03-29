﻿using Backend.Entities.UniversityEntities;
using Backend.Repositories.GenericRepository;

namespace Backend.Repositories.University.DepartmentRepository;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly IGenericRepository<Department> _repository;

    public DepartmentRepository(IGenericRepository<Department> repository)
    {
        _repository = repository;
    }

    public IQueryable<Department> GetAll()
    {
        return _repository.GetAll();
    }

    public Task<Department?> GetById(int id)
    {
        return _repository.GetById(id);
    }

    public Task Save(Department department)
    {
        return _repository.Save(department);
    }

    public Task Update(Department department)
    {
        return _repository.Update(department);
    }

    public Task Delete(Department department)
    {
        return _repository.Delete(department);
    }
}