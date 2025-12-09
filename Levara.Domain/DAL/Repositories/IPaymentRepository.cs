using Levara.Domain.Models;

namespace Levara.Domain.DAL.Repositories;

public interface IPaymentRepository : IRepository<Payment>
{
    IQueryable<Payment> GetAllWithOwnerBankAccount();

    IQueryable<Payment> GetAllWithProperty();

    IQueryable<Payment> GetAllFull();

    Task<decimal> GetLastPropertyPaymentRunningBalanceAsync(int propertyId);

    Task<decimal> GetLastBankAccountRunningBalanceAsync(int ownerBankAccountId);

    Task<decimal> GetLastLeasePaymentRunningBalanceAsync(int leaseId);
}
