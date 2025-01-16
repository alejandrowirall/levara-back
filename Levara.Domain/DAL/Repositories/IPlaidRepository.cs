using Levara.Domain.Models;

namespace Levara.Domain.DAL.Repositories;

public interface IPlaidRepository : IRepository<PlaidTransaction>
{
    IQueryable<PlaidTransaction> GetAllWithOwnerBankAccount();

    IQueryable<PlaidTransaction> GetAllWithOwner();
}
