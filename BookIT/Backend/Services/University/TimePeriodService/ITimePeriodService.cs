using Backend.Entities.UniversityEntities;

namespace Backend.Services.University.TimePeriodService;

public interface ITimePeriodService
{
    public IList<TimePeriod> GetAll();
    public Task<TimePeriod?> GetById(int id);
    public Task Save(TimePeriod timePeriod);
    public Task Update(TimePeriod timePeriod);
    public Task Delete(TimePeriod timePeriod);
}