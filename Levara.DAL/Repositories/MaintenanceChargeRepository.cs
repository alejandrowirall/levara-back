using Levara.Domain.Contexts;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;

namespace Levara.DAL.Repositories;

public class MaintenanceChargeRepository : Repository<MaintenanceCharge>, IMaintenanceChargeRepository
{
    public MaintenanceChargeRepository(UnitOfWork unitOfWork,
        IUserContext userContext) : base(unitOfWork, userContext)
    {

    }
}
