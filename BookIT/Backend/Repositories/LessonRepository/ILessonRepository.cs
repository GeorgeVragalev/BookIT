using Backend.Entities.LessonEntities;
using Backend.Repositories.GenericRepository;

namespace Backend.Repositories.LessonRepository;

public interface ILessonRepository : IGenericRepository<Lesson>
{
    public Task<Lesson?> GetByName(string lessonName);
}