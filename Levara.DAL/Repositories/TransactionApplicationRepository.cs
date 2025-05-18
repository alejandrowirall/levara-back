
using Levara.Domain.Contexts;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Levara.DAL.Repositories;

public class TransactionApplicationRepository : Repository<TransactionApplication>, ITransactionApplicationRepository
{
    public TransactionApplicationRepository(UnitOfWork unitOfWork, 
        IUserContext userContext) : base(unitOfWork, userContext)
    {

    }

    public IQueryable<TransactionApplication> GetAllFull()
    {
        return GetAll().Include(ta => ta.Payment).ThenInclude(ct => ct.Property).ThenInclude(p => p.Address)
                       .Include(ta => ta.ChargeTransaction)
                       .Include(ta => ta.PaymentTransaction);
    }

}
