using Backend.Entities.Rooms;
using Backend.Repositories.GenericRepository;

namespace Backend.Repositories.RoomFolder.FacilityRepository;

public class FacilityRepository : IFacilityRepository
{
    private readonly IGenericRepository<Facility> _repository;

    public FacilityRepository(IGenericRepository<Facility> repository)
    {
        _repository = repository;
    }

    public IQueryable<Facility> GetAll()
    {
        return _repository.GetAll();
    }

    public Task<Facility?> GetById(int id)
    {
        return _repository.GetById(id);
    }

    public Task Save(Facility facility)
    {
        return _repository.Save(facility);
    }

    public Task Update(Facility facility)
    {
        return _repository.Update(facility);
    }

    public Task Delete(Facility facility)
    {
        return _repository.Delete(facility);
    }
}