using Backend.Entities.Users;

namespace Backend.Services.Users.TeacherService;

public interface ITeacherService
{
    public IList<Teacher> GetAll();
    public Task<Teacher?> GetById(int id);
    public Task<Teacher?> GetByEmail(string email);
    public Task Save(Teacher teacher);
    public Task Update(Teacher teacher);
    public Task Delete(Teacher teacher);
}