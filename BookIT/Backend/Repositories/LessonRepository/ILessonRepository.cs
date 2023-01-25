using Backend.Entities.LessonEntities;
using Backend.Repositories.GenericRepository;

namespace Backend.Repositories.LessonRepository;

public interface ILessonRepository
{
    public Task<Lesson?> GetByName(string lessonName);
    public IQueryable<Lesson> GetAll();
    public Task<Lesson?> GetById(int id);
    public Task Save(Lesson item);
    public Task Update(Lesson item);
    public Task Delete(Lesson item);
}