
using Boilerplate.Domain.Contexts;
using Boilerplate.Domain.DAL.Repositories;
using Boilerplate.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.DAL.Repositories;

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
}
