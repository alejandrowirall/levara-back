using Levara.Domain.Contexts;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;

namespace Levara.DAL.Repositories;

public class ExpensePaymentRepository : Repository<ExpensePayment>, IExpensePaymentRepository
{
    public ExpensePaymentRepository(UnitOfWork unitOfWork,
        IUserContext userContext) : base(unitOfWork, userContext)
    {

    }
}
