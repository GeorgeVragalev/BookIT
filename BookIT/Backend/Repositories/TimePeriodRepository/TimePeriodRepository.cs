using Backend.Entities.UniversityEntities;
using Backend.Repositories.GenericRepository;

namespace Backend.Repositories.TimePeriodRepository;

public class TimePeriodRepository : ITimePeriodRepository
{
    private readonly IGenericRepository<TimePeriod> _repository;

    public TimePeriodRepository(IGenericRepository<TimePeriod> repository)
    {
        _repository = repository;
    }

    public IQueryable<TimePeriod> GetAll()
    {
        return _repository.GetAll();
    }

    public Task<TimePeriod?> GetById(int id)
    {
        return _repository.GetById(id);
    }

    public Task Save(TimePeriod room)
    {
        return _repository.Save(room);
    }

    public Task Update(TimePeriod room)
    {
        return _repository.Update(room);
    }

    public Task Delete(TimePeriod room)
    {
        return _repository.Delete(room);
    }
}