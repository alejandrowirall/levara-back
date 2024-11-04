using Levara.Domain.Models;

namespace Levara.Domain.DAL.Repositories;

public interface ITenantRepository : IRepository<Tenant>
{
    IQueryable<Tenant> GetAllWithAddress();
}
