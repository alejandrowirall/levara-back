
using Boilerplate.Domain.Contexts;
using Boilerplate.Domain.DAL.Repositories;
using Boilerplate.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.DAL.Repositories;

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
