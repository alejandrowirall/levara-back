using Levara.Domain.Models;

namespace Levara.Domain.DAL.Repositories;

public interface IPropertyRepository : IRepository<Property>
{
    IQueryable<Property> GetAllWithAddress();
    Task<Property?> GetByExternalIdAsync(string externalId);
}
