using Backend.Entities.Rooms;
using Backend.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.GenericRepository;

public interface IGenericRepository<T>
{
    public IQueryable<T> Table {get;}
    public IQueryable<T> GetAll();
    public Task<T?> GetById(int id);
    public Task Save(T item);
    public Task Update(T item);
    public Task Delete(T item);
}