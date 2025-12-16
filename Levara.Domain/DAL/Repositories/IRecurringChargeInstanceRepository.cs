using Levara.Domain.Models;

namespace Levara.Domain.DAL.Repositories;

public interface IRecurringChargeInstanceRepository : IRepository<RecurringChargeInstance>
{
    IQueryable<RecurringChargeInstance> GetAllFull();
}
