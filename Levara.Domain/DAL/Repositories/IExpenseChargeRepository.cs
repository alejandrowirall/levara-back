using Levara.Domain.Models;

namespace Levara.Domain.DAL.Repositories;

public interface IExpenseChargeRepository : IRepository<ExpenseCharge>
{
    IQueryable<ExpenseCharge> GetAllFull();
}
