using Backend.Entities.Users;

namespace Backend.Services.Users.StudentService;

public interface IStudentService
{
    public IList<Student> GetAll();
    public Task<Student?> GetById(int id);
    public Task<Student?> GetByEmail(string email);
    public Task Save(Student student);
    public Task Update(Student student);
    public Task Delete(Student student);
}