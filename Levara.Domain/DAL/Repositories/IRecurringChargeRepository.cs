using Levara.Domain.Models;

namespace Levara.Domain.DAL.Repositories;

public interface IRecurringChargeRepository : IRepository<RecurringCharge>
{
    IQueryable<RecurringCharge> GetAllFull();
}
