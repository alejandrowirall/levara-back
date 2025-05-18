using Levara.Domain.Models;

namespace Levara.Domain.DAL.Repositories;

public interface IPlaidReconciliationRepository : IRepository<PlaidReconciliation>
{
    IQueryable<PlaidReconciliation> GetAllFull();
}
