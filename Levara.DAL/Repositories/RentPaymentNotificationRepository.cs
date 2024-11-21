
using Levara.Domain.Contexts;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;

namespace Levara.DAL.Repositories;

public class RentPaymentNotificationRepository : Repository<RentPaymentNotification>, IRentPaymentNotificationRepository
{
    public RentPaymentNotificationRepository(UnitOfWork unitOfWork, 
        IUserContext userContext) : base(unitOfWork, userContext)
    {

    }
}
