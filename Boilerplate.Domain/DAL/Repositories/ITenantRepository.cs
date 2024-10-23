using Boilerplate.Domain.Models;

namespace Boilerplate.Domain.DAL.Repositories;

public interface ITenantRepository : IRepository<Tenant>
{
    IQueryable<Tenant> GetAllWithAddress();
}
