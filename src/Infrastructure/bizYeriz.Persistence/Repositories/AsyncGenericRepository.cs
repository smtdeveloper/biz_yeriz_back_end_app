using AutoMapper;
using AutoMapper.QueryableExtensions;
using bizyeriz.Application.Interfaces.Repositories;
using System.Linq.Expressions;

namespace bizYeriz.Persistence.Repositories;

public class AsyncGenericRepository< TEntity, TEntityId> : IAsyncGenericRepository<TEntity, TEntityId> where TEntity : class
{

    protected readonly AppDbContext _context;
    protected readonly IMapper _mapper; 
    private readonly DbSet<TEntity> _dbSet;
    private AppDbContext context;

    public AsyncGenericRepository(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
        _dbSet = _context.Set<TEntity>();
    }

    public AsyncGenericRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task AddAsync(TEntity entity ,CancellationToken cancellationToken)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken)
    {
        return await _dbSet.AnyAsync(expression);
    }



    public async Task<TEntity> GetByIdAsync(TEntityId id, CancellationToken cancellationToken)
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

    public async Task<TEntity> Update(TEntity entity)
    {
        _dbSet.Update(entity);
        return entity;        
    }

    public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
    {
        return _dbSet.Where(expression);
    }
    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        _dbSet.UpdateRange(entities);   
    }

    public async Task<ICollection<TEntity>> GetAllAsync(CancellationToken cancellationToken, Expression<Func<TEntity, bool>>? expression = null)
    {
        var result = _dbSet.AsQueryable();

        if (expression != null)
            result = result.Where(expression);

        return await result.ToListAsync(cancellationToken);
    }

    public async Task<ICollection<TProjectionDto>> GetAllAsync<TProjectionDto>(CancellationToken cancellationToken, Expression<Func<TProjectionDto, bool>>? expression = null)
    {
        var query = _dbSet.AsQueryable().ProjectTo<TProjectionDto>(_mapper.ConfigurationProvider);
        if (expression is not null)
            query = query.Where(expression);

        return await query.ToListAsync(cancellationToken: cancellationToken);
    }
}
