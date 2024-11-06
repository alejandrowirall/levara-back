using Boilerplate.Domain.Models;

namespace Boilerplate.Domain.DAL.Repositories;

public interface ILeaseRepository : IRepository<Lease>
{
    IQueryable<Lease> GetAllLeases();
}
