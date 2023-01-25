using Backend.Entities.UniversityEntities;
using Backend.Repositories.GenericRepository;

namespace Backend.Repositories.University.SubjectRepository;

public interface ISubjectRepository
{
    public Task<Subject?> GetByName(string name);
    public IQueryable<Subject> GetAll();
    public Task<Subject?> GetById(int id);
    public Task Save(Subject item);
    public Task Update(Subject item);
    public Task Delete(Subject item);
}