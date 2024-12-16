using Levara.Domain.Contexts;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;

namespace Levara.DAL.Repositories;

public class MaintenanceTypeRepository : Repository<MaintenanceType>, IMaintenanceTypeRepository
{
    public MaintenanceTypeRepository(UnitOfWork unitOfWork,
        IUserContext userContext) : base(unitOfWork, userContext)
    {

    }
}
