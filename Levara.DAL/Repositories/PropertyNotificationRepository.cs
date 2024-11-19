
using Levara.Domain.Contexts;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;

namespace Levara.DAL.Repositories;

public class PropertyNotificationRepository : Repository<PropertyNotification>, IPropertyNotificationRepository
{
    public PropertyNotificationRepository(UnitOfWork unitOfWork, 
        IUserContext userContext) : base(unitOfWork, userContext)
    {

    }
}
