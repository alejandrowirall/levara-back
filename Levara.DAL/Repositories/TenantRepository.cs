using Levara.Domain.Contexts;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Levara.DAL.Repositories;

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

    public async Task<Tenant?> GetByExternalIdAsync(string externalId)
    {
        var query = GetAll().Where(t => t.ExternalId == externalId);
        return await FirstOrDefaultAsync(query);
    }
}
