using Backend.Entities.Rooms;

namespace Backend.Services.Rooms.RoomService;

public interface IRoomService
{
    public IList<Room> GetAll();
    public Task<Room?> GetById(int id);
    public Task<Room?> GetByName(string roomName);
    public Task Save(Room room);
    public Task Update(Room room);
    public Task Delete(Room room);
}