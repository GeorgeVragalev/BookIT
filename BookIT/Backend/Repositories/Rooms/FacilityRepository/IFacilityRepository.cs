using Backend.Entities.Rooms;
using Backend.Repositories.GenericRepository;

namespace Backend.Repositories.Rooms.FacilityRepository;

public interface IFacilityRepository
{
    public IQueryable<Facility> GetAll();
    public Task<Facility?> GetById(int id);
    public Task Save(Facility item);
    public Task Update(Facility item);
    public Task Delete(Facility item);
}