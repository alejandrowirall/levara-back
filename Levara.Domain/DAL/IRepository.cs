using Levara.Domain.Models;
using System.Linq.Expressions;

namespace Levara.Domain.DAL;

public interface IRepository<TEntity> where TEntity : Entity
{
    Task<TEntity?> GetByIdAsync(int id);
    IQueryable<TEntity> GetAll();
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<IEnumerable<T>> ToListAsync<T>(IQueryable<T> query);
    Task<T?> FirstOrDefaultAsync<T>(IQueryable<T> query);
    Task<PagedList<T>> ToListPagedAsync<T>(IQueryable<T> query, int pageNumber, int pageSize);
    Task<CursorPagedList<TEntity>> ToListCursorAsync(IQueryable<TEntity> query, int pageSize, int? cursor = null);
    Task<IEnumerable<TEntity>> GetByFilterAsync(Expression<Func<TEntity, bool>> filter, int pageNumber, int pageSize);
    Task AddAsync(TEntity entity);
    Task AddAsync(List<TEntity> entities);
    void Update(TEntity entity);
    void Update(List<TEntity> entities);
    void Delete(TEntity entity);
    Task<int> CountAsync(Expression<Func<TEntity, bool>>? filter = null);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? filter = null);
}
