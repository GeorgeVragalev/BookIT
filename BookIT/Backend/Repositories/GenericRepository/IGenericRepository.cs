using Backend.Entities.Users;

namespace Backend.Repositories.GenericRepository;

public interface IGenericRepository<T>
{
    public IQueryable<T> GetAll();
    public Task<T?> GetById(int id);
    public Task Save(T item);
    public Task Update(T item);
    public Task Delete(T item);
}