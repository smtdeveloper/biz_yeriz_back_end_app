using bizyeriz.Application.Interfaces.Repositories;
using System.Linq.Expressions;

namespace bizYeriz.Persistence.Repositories;

public class AsyncGenericRepository< TEntity, TEntityId> : IAsyncGenericRepository<TEntity, TEntityId> where TEntity : class
{

    protected readonly AppDbContext _context;
    private readonly DbSet<TEntity> _dbSet;
    public AsyncGenericRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }


    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await _dbSet.AnyAsync(expression);
    }

    public IQueryable<TEntity> GetAll()
    {
        return _dbSet.AsNoTracking().AsQueryable();
    }

    public async Task<TEntity> GetByIdAsync(TEntityId id)
    {
        return await _dbSet.FindAsync(id);
    }

    public void Remove(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        _dbSet.RemoveRange(entities);
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
    {
        return _dbSet.Where(expression);
    }
    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        _dbSet.UpdateRange(entities);   
    }

}
