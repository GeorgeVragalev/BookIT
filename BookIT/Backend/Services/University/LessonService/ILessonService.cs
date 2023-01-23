using Backend.Entities.LessonEntities;

namespace Backend.Services.University.LessonService;

public interface ILessonService
{
    public IList<Lesson> GetAll();
    public Task<Lesson?> GetById(int id);
    public Task<Lesson?> GetByLessonName(string lessonName);
    public Task Save(Lesson lesson);
    public Task Update(Lesson lesson);
    public Task Delete(Lesson lesson);
}