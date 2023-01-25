using Backend.Entities.LessonEntities;
using Backend.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.LessonRepository;

public class LessonRepository : ILessonRepository
{
    private readonly IGenericRepository<Lesson> _repository;

    public LessonRepository(IGenericRepository<Lesson> repository)
    {
        _repository = repository;
        repository.Table
            .Include(d => d.Group)
            .Include(c => c.Subject)
            .Include(c => c.Room)
            .Include(c => c.Teacher)
            .Include(c => c.TimePeriod);
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