
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
        return GetAll().Include(o => o.Address);
    }
}
