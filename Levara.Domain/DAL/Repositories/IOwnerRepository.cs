using Levara.Domain.Models;

namespace Levara.Domain.DAL.Repositories;

public interface IOwnerRepository : IRepository<Owner>
{
    IQueryable<Owner> GetAllWithAddress();
    Task<Owner?> GetByExternalIdAsync(string externalId);
}
