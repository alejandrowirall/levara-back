using Levara.Domain.Models;

namespace Levara.Domain.DAL.Repositories;

public interface ITransactionApplicationRepository : IRepository<TransactionApplication>
{
    IQueryable<TransactionApplication> GetAllFull();

    Task<decimal> GetTotalAppliedAmountByChargeTransactionAsync(int chargeTransactionId);
}
