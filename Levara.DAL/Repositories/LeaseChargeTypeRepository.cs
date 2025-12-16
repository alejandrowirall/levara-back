using Levara.Domain.Contexts;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;

namespace Levara.DAL.Repositories;

public class LeaseChargeTypeRepository : Repository<LeaseChargeType>, ILeaseChargeTypeRepository
{
    public LeaseChargeTypeRepository(UnitOfWork unitOfWork,
        IUserContext userContext) : base(unitOfWork, userContext)
    {

    }
}
