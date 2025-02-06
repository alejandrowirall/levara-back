using Levara.Domain.Contexts;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Levara.DAL.Repositories
{
    public class BankTransactionRepository : Repository<BankTransaction>, IBankTransactionRepository
    {
        public BankTransactionRepository(UnitOfWork unitOfWork,
        IUserContext userContext) : base(unitOfWork, userContext)
        {

        }

        public IQueryable<BankTransaction> GetAllWithOwnerBankAccount()
        {
            return GetAll().Include(bt => bt.OwnerBankAccount);
        }

        public IQueryable<BankTransaction> GetAllWithProperty()
        {
            return GetAll().Include(bt => bt.Property).ThenInclude(p => p.Address);
        }
    }
}
