using Levara.Domain.Models;

namespace Levara.Domain.DAL.Repositories;

public interface ILeaseRepository : IRepository<Lease>
{
    IQueryable<Lease> GetAllFull();
    Task<Lease?> GetByExternalIdAsync(string externalId);
}
