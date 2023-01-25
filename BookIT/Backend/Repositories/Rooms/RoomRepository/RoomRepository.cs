using System.Data.Entity;
using Backend.Entities.Rooms;
using Backend.Repositories.GenericRepository;

namespace Backend.Repositories.Rooms.RoomRepository;

public class RoomRepository : IRoomRepository
{
    private readonly IGenericRepository<Room> _repository;

    public RoomRepository(IGenericRepository<Room> repository)
    {
        _repository = repository;
        _repository.Table
            .Include(c => c.Lessons)
            .Include(c => c.Facilities);
    }

    public IQueryable<Room> GetAll()
    {
        return _repository.GetAll().Include(c=>c.Lessons);
    }

    public Task<Room?> GetById(int id)
    {
        return _repository.GetById(id);
    }

    public Task<Room?> GetByName(string name)
    {
        return Task.FromResult(_repository.GetAll().FirstOrDefault(room => room.Name ==name));
    }

    public Task Save(Room room)
    {
        return _repository.Save(room);
    }

    public Task Update(Room room)
    {
        return _repository.Update(room);
    }

    public Task Delete(Room room)
    {
        return _repository.Delete(room);
    }
}