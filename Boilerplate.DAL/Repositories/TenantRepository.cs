using Boilerplate.Domain.DAL.Repositories;
using Boilerplate.Domain.Models;
using Boilerplate.Shared.Domain.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.DAL.Repositories;

public class TenantRepository : Repository<Tenant>, ITenantRepository
{
    public TenantRepository(UnitOfWork unitOfWork, 
        IUserContext userContext) : base(unitOfWork, userContext)
    {

    }

    public IQueryable<Tenant> GetAllWithAddress()
    {
        return GetAll().Include(o => o.Address);
    }
}
