using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Prototipo.Exemplo.Domain._Shared.Entities;
using Prototipo.Exemplo.Domain._Shared.Exceptions;

namespace Prototipo.Exemplo.Infra.Postgress._Shared.Repositories;

public class BaseRepository<TEntity, TKey> : IRepository<TEntity, TKey>
    where TKey : EntityId
    where TEntity : Entity<TKey>
{

    private readonly DbContext _dbContext;

    public BaseRepository(DbContext dbContext)
        => _dbContext = dbContext;

    public async Task<TEntity?> FindAsync(TKey id)
        => await _dbContext
            .Set<TEntity>()
            .FindAsync(new object[] { id });

    public async Task<TEntity?> FindAsyncWithDetails(TKey id, params Expression<Func<TEntity, object>>[] propertySelectors)
        => await WithDetails(propertySelectors)
            .Where(o => o.Id == id)
            .SingleOrDefaultAsync();

    public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate)
        => await _dbContext
            .Set<TEntity>()
            .Where(predicate)
            .SingleOrDefaultAsync();

    public async Task<TEntity> GetAsync(TKey id)
        => await FindAsync(id) ?? throw new EntityNotFoundException(typeof(TEntity), id);

    public async Task<TEntity> GetAsyncWithDetails(TKey id, params Expression<Func<TEntity, object>>[] propertySelectors)
        => await FindAsyncWithDetails(id, propertySelectors) ?? throw new EntityNotFoundException(typeof(TEntity), id);

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, bool includeDetails = true)
        => await FindAsync(predicate) ?? throw new EntityNotFoundException(typeof(TEntity));

    public async Task<IEnumerable<TEntity>> GetListAsync()
        => await _dbContext
            .Set<TEntity>()
            .ToListAsync();

    public async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate)
         => await _dbContext
            .Set<TEntity>()
            .Where(predicate)
            .ToListAsync();

    public async Task<List<TEntity>> GetPagedListAsync(int skipCount, int maxResultCount, string sorting)
        => await _dbContext
            .Set<TEntity>()
            .ToListAsync();

    public IQueryable<TEntity> GetQueryable()
        => _dbContext
            .Set<TEntity>()
            .AsQueryable();

    public IQueryable<TEntity> WithDetails(params Expression<Func<TEntity, object>>[] propertySelectors)
        => IncludeDetails(GetQueryable(), propertySelectors);

    public async Task<bool> ExistsAsync(TKey id)
        => await GetQueryable()
            .Where(o => o.Id == id)
            .AnyAsync();

    public async Task InsertAsync(TEntity entity)
        => await _dbContext
            .Set<TEntity>()
            .AddAsync(entity);

    public async Task InsertAsync(IEnumerable<TEntity> entities)
        => await _dbContext
            .Set<TEntity>()
            .AddRangeAsync(entities);

    public void Update(TEntity entity)
    {
        _dbContext.Attach(entity);
        _dbContext.Update(entity);
    }

    public void Update(IEnumerable<TEntity> entities)
        => _dbContext
            .Set<TEntity>()
            .UpdateRange(entities);

    public void Delete(TEntity entity)
        => _dbContext
            .Set<TEntity>()
            .Remove(entity);

    public void Delete(IEnumerable<TEntity> entities)
        => _dbContext
            .Set<TEntity>()
            .RemoveRange(entities);

    private static IQueryable<TEntity> IncludeDetails(IQueryable<TEntity> query, Expression<Func<TEntity, object>>[] propertySelectors)
    {
        if (propertySelectors != null)
        {
            foreach (var propertySelector in propertySelectors)
            {
                query = query.Include(propertySelector);
            }
        }

        return query;
    }

    private static IQueryable<TEntity> IncludeDetails(IQueryable<TEntity> query, string[] propertySelectors)
    {
        if (propertySelectors != null)
        {
            foreach (var propertySelector in propertySelectors)
            {
                query = query.Include(propertySelector);
            }
        }

        return query;
    }
}