
using Levara.Domain.Contexts;
using Levara.Domain.DAL;
using Levara.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Levara.DAL;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    private readonly DbSet<TEntity> _dbSet;
    protected readonly IUserContext _userContext;

    public Repository(UnitOfWork unitOfWork, 
        IUserContext userContext)
    {
        _dbSet = unitOfWork.Context.Set<TEntity>();
        _userContext = userContext;
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public IQueryable<TEntity> GetAll()
    {
        return _dbSet.AsQueryable();
    }

    public async Task<IEnumerable<T>> ToListAsync<T>(IQueryable<T> query)
    {
        return await query.ToListAsync();
    }

    public async Task<T?> FirstOrDefaultAsync<T>(IQueryable<T> query)
    {
        return await query.FirstOrDefaultAsync();
    }

    public async Task<PagedList<T>> ToListPagedAsync<T>(IQueryable<T> query, int pageNumber, int pageSize)
    {
        int count = await query.CountAsync();

        var result = await query.Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize) 
                                .ToListAsync();

        return new PagedList<T>(result, count, pageNumber, pageSize);
    }

    public async Task<CursorPagedList<TEntity>> ToListCursorAsync(IQueryable<TEntity> query, int pageSize, int? cursor = null)
    {
        if (cursor.HasValue)
        {
            query = query.Where(entity => entity.Id < cursor.Value);
        }

        query = query.OrderByDescending(entity => entity.Id);

        var result = await query.Take(pageSize).ToListAsync();

        int? nextCursor = null;
        if (result.Count == pageSize && await query.AnyAsync(entity => entity.Id < result.Last().Id))
            nextCursor = result.Last().Id;

        return new CursorPagedList<TEntity>(result, nextCursor);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> GetByFilterAsync(Expression<Func<TEntity, bool>> filter, int pageNumber, int pageSize)
    {
        return await _dbSet
            .Where(filter)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task AddAsync(TEntity entity)
    {
        entity.CreatedDate = DateTime.UtcNow;
        entity.CreatorId = _userContext.Id;
        entity.LastEditedDate = DateTime.UtcNow;
        entity.LastEditorId = _userContext.Id;

        await _dbSet.AddAsync(entity);
    }

    public async Task AddAsync(List<TEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.CreatedDate = DateTime.UtcNow;
            entity.CreatorId = _userContext.Id;
            entity.LastEditedDate = DateTime.UtcNow;
            entity.LastEditorId = _userContext.Id;
        }

        await _dbSet.AddRangeAsync(entities);
    }

    public void Update(TEntity entity)
    {
        entity.LastEditedDate = DateTime.UtcNow;
        entity.LastEditorId = _userContext.Id;

        _dbSet.Update(entity);
    }

    public void Update(List<TEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.LastEditedDate = DateTime.UtcNow;
            entity.LastEditorId = _userContext.Id;
        }

        _dbSet.UpdateRange(entities);
    }

    public void Delete(TEntity entity)
    {
        entity.LastEditedDate = DateTime.UtcNow;
        entity.LastEditorId = _userContext.Id;
        entity.Deleted = true;

        _dbSet.Update(entity);
    }

    public async Task<int> CountAsync(Expression<Func<TEntity, bool>>? filter = null)
    {
        return filter == null ? await _dbSet.CountAsync() : await _dbSet.CountAsync(filter);
    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? filter = null)
    {
        return filter == null ? await _dbSet.AnyAsync() : await _dbSet.AnyAsync(filter);
    }
}
