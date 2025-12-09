using Levara.Domain.Contexts;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Levara.DAL.Repositories;

public class PlaidReconciliationRepository : Repository<PlaidReconciliation>, IPlaidReconciliationRepository
{
    public PlaidReconciliationRepository(UnitOfWork unitOfWork,
        IUserContext userContext) : base(unitOfWork, userContext)
    {

    }

    public IQueryable<PlaidReconciliation> GetAllFull()
    {
        return GetAll().Include(l => l.PlaidTransaction)
                       .Include(lc => lc.Transaction).ThenInclude(t => t.Property).ThenInclude(t => t.Address);
    }
}
