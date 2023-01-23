using Backend.Entities.UniversityEntities;
using Backend.Repositories.TimePeriodRepository;
using Backend.Services.University.LessonService;

namespace Backend.Services.University.TimePeriodService;

public class TimePeriodService : ITimePeriodService
{
    private readonly ITimePeriodRepository _timePeriodRepository;

    public TimePeriodService(ITimePeriodRepository timePeriodRepository)
    {
        _timePeriodRepository = timePeriodRepository;
    }

    public IList<TimePeriod> GetAll()
    {
        return _timePeriodRepository.GetAll().ToList();
    }

    public Task<TimePeriod?> GetById(int id)
    {
        return _timePeriodRepository.GetById(id);
    }

    public Task Save(TimePeriod timePeriod)
    {
        return _timePeriodRepository.Save(timePeriod);
    }

    public Task Update(TimePeriod timePeriod)
    {
        return _timePeriodRepository.Update(timePeriod);
    }

    public Task Delete(TimePeriod timePeriod)
    {
        return _timePeriodRepository.Delete(timePeriod);
    }
}