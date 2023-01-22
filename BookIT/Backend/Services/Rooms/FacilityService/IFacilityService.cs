using Backend.Entities.Rooms;

namespace Backend.Services.Rooms.FacilityService;

public interface IFacilityService
{
    public IList<Facility> GetAll();
    public Task<Facility?> GetById(int id);
    public Task Save(Facility facility);
    public Task Update(Facility facility);
    public Task Delete(Facility facility);
}