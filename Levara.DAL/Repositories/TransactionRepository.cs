
using Levara.Domain.Contexts;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Levara.DAL.Repositories;

public class TransactionRepository : Repository<Transaction>, ITransactionRepository
{
    public TransactionRepository(UnitOfWork unitOfWork, 
        IUserContext userContext) : base(unitOfWork, userContext)
    {

    }

    public IQueryable<Transaction> GetAllWithProperty()
    {
        return GetAll().Include(o => o.Property);
    }

    public IQueryable<Transaction> GetAllFull()
    {
        return GetAll().Include(o => o.Property).ThenInclude(p => p.Address)
                       .Include(o => o.Property).ThenInclude(p => p.Owner)
                       .Include(o => o.Lease);
    }

    public async Task<decimal> GetLastLeaseRunningBalanceAsync(int leaseId)
    {
        var lastLeaseTransaction = await GetAll()
            .Where(t => t.LeaseId == leaseId)
            .OrderByDescending(t => t.CreatedDate)
            .FirstOrDefaultAsync();

        return lastLeaseTransaction?.LeaseRunningBalance ?? 0;
    }

    public async Task<Dictionary<int, decimal>> GetLastLeaseRunningBalancesAsync(IEnumerable<int> leaseIds)
    {
        var leaseIdsList = leaseIds.ToList();
        if (!leaseIdsList.Any())
            return new Dictionary<int, decimal>();

        return await GetAll()
            .Where(t => t.LeaseId.HasValue && leaseIdsList.Contains(t.LeaseId.Value))
            .GroupBy(t => t.LeaseId!.Value)
            .ToDictionaryAsync(
                g => g.Key,
                g => g.OrderByDescending(t => t.CreatedDate).First().LeaseRunningBalance ?? 0
            );
    }

    public async Task<decimal> GetLastPropertyRunningBalanceAsync(int propertyId)
    {
        var lastPropertyTransaction = await GetAll()
            .Where(t => t.PropertyId == propertyId)
            .OrderByDescending(t => t.CreatedDate)
            .FirstOrDefaultAsync();

        return lastPropertyTransaction?.RunningBalance ?? 0;
    }
}
