using Boilerplate.Domain.Models;

namespace Boilerplate.Domain.DAL;

public interface IUnitOfWork : IDisposable
{
    IRepository<TEntity> Repository<TEntity>() where TEntity : Entity;
    Task<int> SaveChangesAsync();
    Task ExecuteAsTransactionAsync(Func<Task> asyncLogic);
}
