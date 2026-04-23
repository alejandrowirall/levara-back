
using Levara.Domain.Contexts;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Levara.DAL.Repositories;

public class PropertyRepository : Repository<Property>, IPropertyRepository
{
    public PropertyRepository(UnitOfWork unitOfWork, 
        IUserContext userContext) : base(unitOfWork, userContext)
    {

    }

    public IQueryable<Property> GetAllWithAddress()
    {
        return GetAll().Include(o => o.Address).Include(x=>x.OwnerBankAccount);
    }

    public async Task<Property?> GetByExternalIdAsync(string externalId)
    {
        var query = GetAll().Where(p => p.ExternalId == externalId);
        return await FirstOrDefaultAsync(query);
    }
}
