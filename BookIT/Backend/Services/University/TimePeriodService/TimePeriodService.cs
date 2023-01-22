using Backend.Entities.UniversityEntities;
using Backend.Repositories.TimePeriodRepository;
using Backend.Services.University.LessonService;

namespace Backend.Services.University.TimePeriodService;

public class TimePeriodService : ITimePeriodService
{
    private readonly ITimePeriodRepository _lessonRepository;

    public TimePeriodService(ITimePeriodRepository lessonRepository)
    {
        _lessonRepository = lessonRepository;
    }

    public IList<TimePeriod> GetAll()
    {
        return _lessonRepository.GetAll().ToList();
    }

    public Task<TimePeriod?> GetById(int id)
    {
        return _lessonRepository.GetById(id);
    }

    public Task Save(TimePeriod lesson)
    {
        return _lessonRepository.Save(lesson);
    }

    public Task Update(TimePeriod lesson)
    {
        return _lessonRepository.Update(lesson);
    }

    public Task Delete(TimePeriod lesson)
    {
        return _lessonRepository.Delete(lesson);
    }
}