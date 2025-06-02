
using Levara.Domain.Contexts;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Levara.DAL.Repositories;

public class LeaseRepository : Repository<Lease>, ILeaseRepository
{
    public LeaseRepository(UnitOfWork unitOfWork, 
        IUserContext userContext) : base(unitOfWork, userContext)
    {

    }

    public IQueryable<Lease> GetAllFull()
    {
        return GetAll().Include(o=>o.Owner)
                       .Include(t=>t.Tenant)
                       .Include(p=>p.Property).Include(a=>a.Property.Address);
    }
}
