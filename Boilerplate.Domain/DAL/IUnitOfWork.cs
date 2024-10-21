namespace Boilerplate.Domain.DAL;

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync();
    Task ExecuteAsTransactionAsync(Func<Task> asyncLogic);
}
