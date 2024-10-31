using Boilerplate.Domain.Models;

namespace Boilerplate.Domain.DAL.Repositories;

public interface IPropertyRepository : IRepository<Property>
{
    IQueryable<Property> GetAllWithAddress();
}
