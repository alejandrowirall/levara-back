using Boilerplate.Domain.Models;
using System.Linq.Expressions;

namespace Boilerplate.Domain.DAL;

public interface IRepository<TEntity> where TEntity : Entity
{
    Task<TEntity?> GetByIdAsync(int id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<IEnumerable<TEntity>> GetByFilterAsync(Expression<Func<TEntity, bool>> filter, int pageNumber, int pageSize);
    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task<int> CountAsync(Expression<Func<TEntity, bool>>? filter = null);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? filter = null);
}
