using Backend.Entities.LessonEntities;
using Backend.Repositories.LessonRepository;

namespace Backend.Services.University.LessonService;

public class LessonService : ILessonService
{
    private readonly ILessonRepository _lessonRepository;

    public LessonService(ILessonRepository lessonRepository)
    {
        _lessonRepository = lessonRepository;
    }

    public IList<Lesson> GetAll()
    {
        return _lessonRepository.GetAll().ToList();
    }

    public Task<Lesson?> GetById(int id)
    {
        return _lessonRepository.GetById(id);
    }

    public Task<Lesson?> GetByLessonName(string lessonName)
    {
        return _lessonRepository.GetByLessonName(lessonName);
    }

    public Task Save(Lesson lesson)
    {
        return _lessonRepository.Save(lesson);
    }

    public Task Update(Lesson lesson)
    {
        return _lessonRepository.Update(lesson);
    }

    public Task Delete(Lesson lesson)
    {
        return _lessonRepository.Delete(lesson);
    }
}