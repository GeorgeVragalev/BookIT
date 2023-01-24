using Backend.Entities.UniversityEntities;

namespace Backend.Services.University.SubjectService;

public interface ISubjectService
{
    public IList<Subject> GetAll();
    public Task<Subject?> GetById(int id);
    public Task<Subject?> GetByName(string subject);
    public Task Save(Subject subject);
    public Task Update(Subject subject);
    public Task Delete(Subject subject);
}