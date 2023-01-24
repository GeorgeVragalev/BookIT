using Backend.Entities.UniversityEntities;
using Backend.Repositories.University.SubjectRepository;

namespace Backend.Services.University.SubjectService;

public class SubjectService : ISubjectService
{
    private readonly ISubjectRepository _subjectRepository;

    public SubjectService(ISubjectRepository subjectRepository)
    {
        _subjectRepository = subjectRepository;
    }

    public IList<Subject> GetAll()
    {
        return _subjectRepository.GetAll().ToList();
    }

    public Task<Subject?> GetById(int id)
    {
        return _subjectRepository.GetById(id);
    }

    public Task<Subject?> GetByName(string subject)
    {
        return _subjectRepository.GetByName(subject);
    }

    public Task Save(Subject subject)
    {
        return _subjectRepository.Save(subject);
    }

    public Task Update(Subject subject)
    {
        return _subjectRepository.Update(subject);
    }

    public Task Delete(Subject subject)
    {
        return _subjectRepository.Delete(subject);
    }
}