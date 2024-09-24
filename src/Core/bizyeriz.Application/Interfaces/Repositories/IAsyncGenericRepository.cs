using System.Linq.Expressions;

namespace bizyeriz.Application.Interfaces.Repositories;

public interface IAsyncGenericRepository<TEntity, TEntityId> where TEntity : class
{
    Task<TEntity> GetByIdAsync(TEntityId id, CancellationToken cancellationToken);
    Task<ICollection<TEntity>> GetAllAsync(CancellationToken cancellationToken, Expression<Func<TEntity, bool>>? expression = null);
    Task<ICollection<TResponse>> GetAllAsync<TResponse>(CancellationToken cancellationToken, Expression<Func<TResponse, bool>>? expression = null);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken);
    Task AddAsync(TEntity entity, CancellationToken cancellationToken);
    Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
    Task<TEntity> Update(TEntity entity);
    void UpdateRange(IEnumerable<TEntity> entities);
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
}
