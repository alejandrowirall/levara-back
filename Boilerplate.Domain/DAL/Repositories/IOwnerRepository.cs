using Boilerplate.Domain.Models;

namespace Boilerplate.Domain.DAL.Repositories;

public interface IOwnerRepository : IRepository<Owner>
{
    IQueryable<Owner> GetAllWithAddress();
}
