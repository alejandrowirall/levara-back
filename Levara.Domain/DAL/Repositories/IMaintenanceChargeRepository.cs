using Levara.Domain.Models;

namespace Levara.Domain.DAL.Repositories;

public interface IMaintenanceChargeRepository : IRepository<MaintenanceCharge>
{
    IQueryable<MaintenanceCharge> GetAllFull();
}
