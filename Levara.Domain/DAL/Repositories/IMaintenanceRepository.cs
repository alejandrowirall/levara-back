using Levara.Domain.Models;

namespace Levara.Domain.DAL.Repositories;

public interface IMaintenanceRepository : IRepository<Maintenance>
{
    IQueryable<Maintenance> GetAllWithMaintananceType();
}
