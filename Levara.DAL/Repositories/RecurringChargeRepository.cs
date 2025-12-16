using Levara.Domain.Contexts;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Levara.DAL.Repositories;

public class RecurringChargeRepository : Repository<RecurringCharge>, IRecurringChargeRepository
{
    public RecurringChargeRepository(UnitOfWork unitOfWork,
        IUserContext userContext) : base(unitOfWork, userContext)
    {

    }

    public IQueryable<RecurringCharge> GetAllFull()
    {
        return GetAll().Include(rc => rc.Property)
                            .ThenInclude(p => p.Address)
                       .Include(rc => rc.Lease)
                            .ThenInclude(l => l.Tenant)
                       .Include(rc => rc.LeaseChargeType)
                       .Include(rc => rc.MaintenanceType)
                       .Include(rc => rc.Expense);
    }
}
