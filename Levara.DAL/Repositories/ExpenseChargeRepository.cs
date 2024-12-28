using Levara.Domain.Contexts;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;

namespace Levara.DAL.Repositories;

public class ExpenseChargeRepository : Repository<ExpenseCharge>, IExpenseChargeRepository
{
    public ExpenseChargeRepository(UnitOfWork unitOfWork,
        IUserContext userContext) : base(unitOfWork, userContext)
    {

    }
}
