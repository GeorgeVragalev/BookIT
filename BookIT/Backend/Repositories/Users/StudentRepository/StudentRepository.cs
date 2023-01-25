using System.Data.Entity;
using Backend.Entities.Users;
using Backend.Repositories.GenericRepository;

namespace Backend.Repositories.Users.StudentRepository;

public class StudentRepository : IStudentRepository
{
    private readonly IGenericRepository<Student> _repository;

    public StudentRepository(IGenericRepository<Student> repository)
    {
        _repository = repository;
        _repository.Table
            .Include(c => c.Group)
            .Include(c => c.User);
    }

    public IQueryable<Student> GetAll()
    {
        return _repository.GetAll();
    }

    public Task<Student?> GetById(int id)
    {
        return _repository.GetById(id);
    }

    public Task<Student?> GetByEmail(string email)
    {
        return Task.FromResult(_repository.GetAll().FirstOrDefault(t => t.User != null && t.User.Email == email));
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