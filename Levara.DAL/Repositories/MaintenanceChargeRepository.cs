using Levara.Domain.Contexts;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Levara.DAL.Repositories;

public class MaintenanceChargeRepository : Repository<MaintenanceCharge>, IMaintenanceChargeRepository
{
    public MaintenanceChargeRepository(UnitOfWork unitOfWork,
        IUserContext userContext) : base(unitOfWork, userContext)
    {

    }

    public IQueryable<MaintenanceCharge> GetAllFull()
    {
        return GetAll().Include(l => l.Maintenance).ThenInclude(m => m.Property)
                       .Include(lc => lc.Transaction);
    }
}
