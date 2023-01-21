using Backend.Entities.Rooms;
using Backend.Repositories.RoomFolder.RoomRepository;

namespace Backend.Services.RoomFolder.RoomService;

public class RoomService : IRoomService
{
    private readonly IRoomRepository _roomRepository;

    public RoomService(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public IList<Room> GetAll()
    {
        return _roomRepository.GetAll().ToList();
    }

    public Task<Room?> GetById(int id)
    {
        return _roomRepository.GetById(id);
    }

    public Task<Room?> GetByRoomName(string roomName)
    {
        return _roomRepository.GetByRoomName(roomName);
    }

    public Task Save(Room room)
    {
        return _roomRepository.Save(room);
    }

    public Task Update(Room room)
    {
        return _roomRepository.Update(room);
    }

    public Task Delete(Room room)
    {
        return _roomRepository.Delete(room);
    }
}