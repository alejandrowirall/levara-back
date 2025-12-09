using Levara.Domain.Contexts;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;

namespace Levara.DAL.Repositories;

public class ExpenseRepository : Repository<Expense>, IExpenseRepository
{
    public ExpenseRepository(UnitOfWork unitOfWork,
        IUserContext userContext) : base(unitOfWork, userContext)
    {

    }
}
