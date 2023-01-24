using Backend.Entities.Rooms;
using Backend.Repositories.GenericRepository;

namespace Backend.Repositories.Rooms.RoomRepository;

public interface IRoomRepository : IGenericRepository<Room>
{
    public Task<Room?> GetByName(string name);
}