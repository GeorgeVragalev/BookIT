using Backend.Entities.Users;
using Backend.Repositories.GenericRepository;

namespace Backend.Repositories.Users.TeacherRepository;

public interface ITeacherRepository : IGenericRepository<Teacher>
{
    public Task<Teacher?> GetByEmail(string email);
}