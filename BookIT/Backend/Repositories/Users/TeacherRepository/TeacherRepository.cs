using System.Data.Entity;
using Backend.Entities.Users;
using Backend.Repositories.GenericRepository;

namespace Backend.Repositories.Users.TeacherRepository;

public class TeacherRepository : ITeacherRepository
{
    private readonly IGenericRepository<Teacher> _repository;

    public TeacherRepository(IGenericRepository<Teacher> repository)
    {
        _repository = repository;
        _repository.Table
            .Include(c => c.Department)
            .Include(c => c.Lessons)
            .Include(c => c.Subjects)
            .Include(c => c.User);
    }

    public IQueryable<Teacher> GetAll()
    {
        return _repository.GetAll();
    }

    public Task<Teacher?> GetById(int id)
    {
        return _repository.GetById(id);
    }

    public Task Save(Teacher teacher)
    {
        return _repository.Save(teacher);
    }

    public Task Update(Teacher teacher)
    {
        return _repository.Update(teacher);
    }

    public Task Delete(Teacher teacher)
    {
        return _repository.Delete(teacher);
    }

    public Task<Teacher?> GetByEmail(string email)
    {
        return Task.FromResult(_repository.GetAll().FirstOrDefault(t => t.User != null && t.User.Email == email));
    }
}