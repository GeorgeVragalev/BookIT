using Backend.Entities.LessonEntities;
using Backend.Repositories.GenericRepository;

namespace Backend.Repositories.LessonRepository;

public class LessonRepository : ILessonRepository
{
    private readonly IGenericRepository<Lesson> _repository;

    public LessonRepository(IGenericRepository<Lesson> repository)
    {
        _repository = repository;
    }

    public IQueryable<Lesson> GetAll()
    {
        return _repository.GetAll();
    }

    public Task<Lesson?> GetById(int id)
    {
        return _repository.GetById(id);
    }

    public Task<Lesson?> GetByName(string lessonName)
    {
        return Task.FromResult(_repository.GetAll().FirstOrDefault(lesson => lesson.Name ==lessonName));
    }

    public Task Save(Lesson lesson)
    {
        return _repository.Save(lesson);
    }

    public Task Update(Lesson lesson)
    {
        return _repository.Update(lesson);
    }

    public Task Delete(Lesson lesson)
    {
        return _repository.Delete(lesson);
    }
}