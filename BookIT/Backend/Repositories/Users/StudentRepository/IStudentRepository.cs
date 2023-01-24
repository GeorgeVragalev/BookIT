using Backend.Entities.Users;
using Backend.Repositories.GenericRepository;

namespace Backend.Repositories.Users.StudentRepository;

public interface IStudentRepository : IGenericRepository<Student>
{
    public Task<Student?> GetByEmail(string email);
}