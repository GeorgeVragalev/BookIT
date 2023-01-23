using Backend.Entities.Users;
using Backend.Repositories.Users.StudentRepository;

namespace Backend.Services.Users.StudentService;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public IList<Student> GetAll()
    {
        return _studentRepository.GetAll().ToList();
    }

    public Task<Student?> GetById(int id)
    {
        return _studentRepository.GetById(id);
    }

    public Task<Student?> GetByEmail(string email)
    {
        return _studentRepository.GetByEmail(email);
    }

    public Task Save(Student student)
    {
        return _studentRepository.Save(student);
    }

    public Task Update(Student student)
    {
        return _studentRepository.Update(student);
    }

    public Task Delete(Student student)
    {
        return _studentRepository.Delete(student);
    }
}