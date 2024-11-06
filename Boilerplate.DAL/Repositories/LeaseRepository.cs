
using Boilerplate.Domain.Contexts;
using Boilerplate.Domain.DAL.Repositories;
using Boilerplate.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.DAL.Repositories;

public class LeaseRepository : Repository<Lease>, ILeaseRepository
{
    public LeaseRepository(UnitOfWork unitOfWork, 
        IUserContext userContext) : base(unitOfWork, userContext)
    {

    }

    public IQueryable<Lease> GetAllLeases()
    {
        return GetAll();
    }
}
