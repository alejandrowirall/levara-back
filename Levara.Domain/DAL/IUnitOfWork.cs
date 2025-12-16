using Levara.Shared.Results;

namespace Levara.Domain.DAL;

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync();
    Task ExecuteAsTransactionAsync(Func<Task> asyncLogic);
    Task<T> ExecuteAsTransactionAsync<T>(Func<Task<T>> asyncLogic);
    Task<OperationResult<T>> ExecuteAsTransactionAsync<T>(Func<Task<OperationResult<T>>> asyncLogic);
}
