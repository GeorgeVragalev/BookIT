using Backend.Entities.UniversityEntities;
using Backend.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.TimePeriodRepository;

public class TimePeriodRepository : ITimePeriodRepository
{
    private readonly IGenericRepository<TimePeriod> _repository;

    public TimePeriodRepository(IGenericRepository<TimePeriod> repository)
    {
        _repository = repository;
        _repository.Table
            .Include(d => d.Lessons);
    }

    public IQueryable<TimePeriod> GetAll()
    {
        return _repository.GetAll();
    }

    public Task<TimePeriod?> GetById(int id)
    {
        return _repository.GetById(id);
    }

    public Task Save(TimePeriod timePeriod)
    {
        return _repository.Save(timePeriod);
    }

    public Task Update(TimePeriod timePeriod)
    {
        return _repository.Update(timePeriod);
    }

    public Task Delete(TimePeriod timePeriod)
    {
        return _repository.Delete(timePeriod);
    }
}