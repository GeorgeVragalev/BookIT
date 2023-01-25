using Backend.Entities.UniversityEntities;
using Backend.Repositories.GenericRepository;

namespace Backend.Repositories.TimePeriodRepository;

public interface ITimePeriodRepository
{
    public IQueryable<TimePeriod> GetAll();
    public Task<TimePeriod?> GetById(int id);
    public Task Save(TimePeriod item);
    public Task Update(TimePeriod item);
    public Task Delete(TimePeriod item);
}