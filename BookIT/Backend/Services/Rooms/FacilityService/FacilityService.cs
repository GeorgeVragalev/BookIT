using Backend.Entities.Rooms;
using Backend.Repositories.Rooms.FacilityRepository;

namespace Backend.Services.Rooms.FacilityService;

public class FacilityService : IFacilityService
{
    private readonly IFacilityRepository _facilityRepository;

    public FacilityService(IFacilityRepository facilityRepository)
    {
        _facilityRepository = facilityRepository;
    }

    public IList<Facility> GetAll()
    {
        return _facilityRepository.GetAll().ToList();
    }

    public Task<Facility?> GetById(int id)
    {
        return _facilityRepository.GetById(id);
    }

    public Task Save(Facility facility)
    {
        return _facilityRepository.Save(facility);
    }

    public Task Update(Facility facility)
    {
        return _facilityRepository.Update(facility);
    }

    public Task Delete(Facility facility)
    {
        return _facilityRepository.Delete(facility);
    }
}