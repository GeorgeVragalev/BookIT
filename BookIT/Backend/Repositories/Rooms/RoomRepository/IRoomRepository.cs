using Backend.Entities.Rooms;
using Backend.Repositories.GenericRepository;

namespace Backend.Repositories.Rooms.RoomRepository;

public interface IRoomRepository
{
    public Task<Room?> GetByName(string name);
    public IQueryable<Room> GetAll();
    public Task<Room?> GetById(int id);
    public Task Save(Room item);
    public Task Update(Room item);
    public Task Delete(Room item);
}