using Levara.Domain.Contexts;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Levara.DAL.Repositories;

public class LeaseChargeRepository : Repository<LeaseCharge>, ILeaseChargeRepository
{
    public LeaseChargeRepository(UnitOfWork unitOfWork,
        IUserContext userContext) : base(unitOfWork, userContext)
    {

    }

    public IQueryable<LeaseCharge> GetAllFull()
    {
        return GetAll().Include(l => l.Lease)
                       .Include(lc => lc.Transaction);
    }
}
