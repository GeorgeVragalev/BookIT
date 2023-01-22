using Backend.Entities.UniversityEntities;
using Backend.Repositories.GenericRepository;

namespace Backend.Repositories.University.SubjectRepository;

public class SubjectRepository : ISubjectRepository
{
    private readonly IGenericRepository<Subject> _repository;

    public SubjectRepository(IGenericRepository<Subject> repository)
    {
        _repository = repository;
    }

    public IQueryable<Subject> GetAll()
    {
        return _repository.GetAll();
    }

    public Task<Subject?> GetById(int id)
    {
        return _repository.GetById(id);
    }

    public Task Save(Subject subject)
    {
        return _repository.Save(subject);
    }

    public Task Update(Subject subject)
    {
        return _repository.Update(subject);
    }

    public Task Delete(Subject subject)
    {
        return _repository.Delete(subject);
    }
}