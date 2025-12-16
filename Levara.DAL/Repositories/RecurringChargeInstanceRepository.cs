using Levara.Domain.Contexts;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Levara.DAL.Repositories;

public class RecurringChargeInstanceRepository : Repository<RecurringChargeInstance>, IRecurringChargeInstanceRepository
{
    public RecurringChargeInstanceRepository(UnitOfWork unitOfWork,
        IUserContext userContext) : base(unitOfWork, userContext)
    {

    }

    public IQueryable<RecurringChargeInstance> GetAllFull()
    {
        return GetAll()
                .Include(o => o.RecurringCharge)
                .Include(o => o.RecurringCharge.Property)
                    .ThenInclude(p => p.Address)
                .Include(o => o.RecurringCharge.Property)
                    .ThenInclude(p => p.Owner)
                .Include(o => o.Transaction);
    }
}
