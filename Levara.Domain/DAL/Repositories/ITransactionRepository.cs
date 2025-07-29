using Levara.Domain.Models;

namespace Levara.Domain.DAL.Repositories;

public interface ITransactionRepository : IRepository<Transaction>
{
    IQueryable<Transaction> GetAllWithProperty();

    IQueryable<Transaction> GetAllFull();

    Task<decimal> GetLastLeaseRunningBalanceAsync(int leaseId);

    Task<Dictionary<int, decimal>> GetLastLeaseRunningBalancesAsync(IEnumerable<int> leaseIds);

    Task<decimal> GetLastPropertyRunningBalanceAsync(int propertyId);
}
