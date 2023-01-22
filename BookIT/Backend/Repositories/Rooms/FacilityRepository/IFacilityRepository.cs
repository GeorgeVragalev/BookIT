using Backend.Entities.Rooms;

namespace Backend.Repositories.Rooms.FacilityRepository;

public interface IFacilityRepository
{
    public IQueryable<Facility> GetAll();
    public Task<Facility?> GetById(int id);
    public Task Save(Facility facility);
    public Task Update(Facility facility);
    public Task Delete(Facility facility);
}