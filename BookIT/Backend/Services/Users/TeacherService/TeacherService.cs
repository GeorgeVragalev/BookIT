using Backend.Entities.Users;
using Backend.Repositories.Users.TeacherRepository;

namespace Backend.Services.Users.TeacherService;

public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _teacherRepository;

    public TeacherService(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    public IList<Teacher> GetAll()
    {
        return _teacherRepository.GetAll().ToList();
    }

    public Task<Teacher?> GetById(int id)
    {
        return _teacherRepository.GetById(id);
    }

    public Task Save(Teacher teacher)
    {
        return _teacherRepository.Save(teacher);
    }

    public Task Update(Teacher teacher)
    {
        return _teacherRepository.Update(teacher);
    }

    public Task Delete(Teacher teacher)
    {
        return _teacherRepository.Delete(teacher);
    }
}