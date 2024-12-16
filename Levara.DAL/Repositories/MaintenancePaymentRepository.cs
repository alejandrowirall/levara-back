using Levara.Domain.Contexts;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;

namespace Levara.DAL.Repositories;

public class MaintenancePaymentRepository : Repository<MaintenancePayment>, IMaintenancePaymentRepository
{
    public MaintenancePaymentRepository(UnitOfWork unitOfWork,
        IUserContext userContext) : base(unitOfWork, userContext)
    {

    }
}
