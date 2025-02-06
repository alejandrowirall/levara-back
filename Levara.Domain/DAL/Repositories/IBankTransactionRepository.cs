using Levara.Domain.Models;

namespace Levara.Domain.DAL.Repositories;

public interface IBankTransactionRepository : IRepository<BankTransaction>
{
    IQueryable<BankTransaction> GetAllWithOwnerBankAccount();

    IQueryable<BankTransaction> GetAllWithProperty();
}
