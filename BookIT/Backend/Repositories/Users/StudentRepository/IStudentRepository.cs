using Backend.Entities.Users;
using Backend.Repositories.GenericRepository;

namespace Backend.Repositories.Users.StudentRepository;

public interface IStudentRepository
{
    public Task<Student?> GetByEmail(string email);
    public IQueryable<Student> GetAll();
    public Task<Student?> GetById(int id);
    public Task Save(Student item);
    public Task Update(Student item);
    public Task Delete(Student item);
}