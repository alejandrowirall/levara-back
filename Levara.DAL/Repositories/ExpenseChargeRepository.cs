using Levara.Domain.Contexts;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Levara.DAL.Repositories;

public class ExpenseChargeRepository : Repository<ExpenseCharge>, IExpenseChargeRepository
{
    public ExpenseChargeRepository(UnitOfWork unitOfWork,
        IUserContext userContext) : base(unitOfWork, userContext)
    {

    }

    public IQueryable<ExpenseCharge> GetAllFull()
    {
        return GetAll().Include(l => l.Expense).ThenInclude(m => m.Property)
                       .Include(lc => lc.Transaction);
    }
}
