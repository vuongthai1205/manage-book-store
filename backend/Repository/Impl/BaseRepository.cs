
using Microsoft.EntityFrameworkCore;

namespace backend;

public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly BookStoreDbContext _db;
    public BaseRepository(BookStoreDbContext _con)
    {
        _db = _con;
    }
    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _db.Set<TEntity>().AddAsync(entity);
        await SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> DeleteAsync(int id)
    {
        var entity = await _db.Set<TEntity>().FindAsync(id);
        _db.Set<TEntity>().Remove(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _db.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _db.Set<TEntity>().FindAsync(id);
    }

    public async Task<int> InsertAsync(TEntity entity)
    {
        _db.Set<TEntity>().Add(entity);

        await _db.SaveChangesAsync();
        return 1;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _db.SaveChangesAsync();
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _db.Entry(entity).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return entity;
    }
}
