using Backend.Entities.Users;
using Backend.Repositories.GenericRepository;

namespace Backend.Repositories.Users.TeacherRepository;

public interface ITeacherRepository
{
    public Task<Teacher?> GetByEmail(string email);
    public IQueryable<Teacher> GetAll();
    public Task<Teacher?> GetById(int id);
    public Task Save(Teacher item);
    public Task Update(Teacher item);
    public Task Delete(Teacher item);
}