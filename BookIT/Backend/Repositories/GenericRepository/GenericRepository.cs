using Backend.Data;
using Backend.Entities.Shared;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.GenericRepository;

public class GenericRepository<T> : IGenericRepository<T> where T : class, IBaseEntity
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;
    public IQueryable<T> Table => _dbSet.AsQueryable();

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public Task<List<T>> GetAll()
    {
        return Table.ToListAsync();
    }

    public async Task<T?> GetById(int id)
    {
        return await Table.Where(it => it.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task Save(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        _dbSet.Add(item);
        await _context.SaveChangesAsync();
    }

    public async Task Update(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        _context.Entry(item).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        _dbSet.Remove(item);
        await _context.SaveChangesAsync();
    }
}