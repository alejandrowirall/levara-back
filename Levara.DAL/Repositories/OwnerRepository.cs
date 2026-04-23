
using Levara.Domain.Contexts;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Levara.DAL.Repositories;

public class OwnerRepository : Repository<Owner>, IOwnerRepository
{
    public OwnerRepository(UnitOfWork unitOfWork, 
        IUserContext userContext) : base(unitOfWork, userContext)
    {

    }

    public IQueryable<Owner> GetAllWithAddress()
    {
        return GetAll().Include(o => o.Address);
    }

    public async Task<Owner?> GetByExternalIdAsync(string externalId)
    {
        var query = GetAll().Where(o => o.ExternalId == externalId);
        return await FirstOrDefaultAsync(query);
    }
}
