using Levara.Domain.Contexts;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Levara.DAL.Repositories
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(UnitOfWork unitOfWork,
        IUserContext userContext) : base(unitOfWork, userContext)
        {

        }

        public IQueryable<Payment> GetAllWithOwnerBankAccount()
        {
            return GetAll().Include(bt => bt.OwnerBankAccount);
        }

        public IQueryable<Payment> GetAllWithProperty()
        {
            return GetAll().Include(bt => bt.Property).ThenInclude(p => p.Address);
        }

        public IQueryable<Payment> GetAllFull()
        {
            return GetAll().Include(bt => bt.OwnerBankAccount)
                           .Include(bt => bt.Property).ThenInclude(p => p.Address);
        }
    }
}
