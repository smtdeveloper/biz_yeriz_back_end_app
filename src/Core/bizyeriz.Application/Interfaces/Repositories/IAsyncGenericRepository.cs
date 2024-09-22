using System.Linq.Expressions;

namespace bizyeriz.Application.Interfaces.Repositories;

public interface IAsyncGenericRepository<TEntity,TEntityId> where TEntity : class
{
    Task<TEntity> GetByIdAsync(TEntityId id);
    IQueryable<TEntity> GetAll();
    IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);
    Task AddAsync(TEntity entity);
    Task AddRangeAsync(IEnumerable<TEntity> entities);
    void Update(TEntity entity);
    void UpdateRange(IEnumerable<TEntity> entities);
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
}
