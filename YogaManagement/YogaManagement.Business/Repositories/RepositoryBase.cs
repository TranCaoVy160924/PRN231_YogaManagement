using Microsoft.EntityFrameworkCore;
using YogaManagement.Database.EF;

namespace YogaManagement.Business.Repositories;

public abstract class RepositoryBase<T> where T : class
{
    private readonly YogaManagementDbContext _dbContext;
    public DbSet<T> Data;

    public RepositoryBase(YogaManagementDbContext dbContext)
    {
        _dbContext = dbContext;
        Data = _dbContext.Set<T>();
    }

    public IQueryable<T> GetAll() => Data.AsQueryable();

    public virtual async Task<T> Get(int id) => await Data.FindAsync(id);

    public async Task CreateAsync(T entity)
    {
        _dbContext.Add(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        var track = _dbContext.Attach(entity);
        track.State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _dbContext.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}
