
using Levara.Domain.Contexts;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Levara.DAL.Repositories;

public class TransactionRepository : Repository<Transaction>, ITransactionRepository
{
    public TransactionRepository(UnitOfWork unitOfWork, 
        IUserContext userContext) : base(unitOfWork, userContext)
    {

    }

    public IQueryable<Transaction> GetAllWithProperty()
    {
        return GetAll().Include(o => o.Property);
    }
}
