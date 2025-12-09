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

        public async Task<decimal> GetLastPropertyPaymentRunningBalanceAsync(int propertyId)
        {
            var lastPropertyPayment = await GetAll()
                                             .Where(p => p.PropertyId == propertyId)
                                             .OrderByDescending(p => p.CreatedDate)
                                             .FirstOrDefaultAsync();

            return lastPropertyPayment?.RunningBalance ?? 0;
        }

        public async Task<decimal> GetLastBankAccountRunningBalanceAsync(int ownerBankAccountId)
        {
            var lastBankAccountPayment = await GetAll()
                                                .Where(p => p.OwnerBankAccountId == ownerBankAccountId)
                                                .OrderByDescending(p => p.CreatedDate)
                                                .FirstOrDefaultAsync();

            return lastBankAccountPayment?.BankAccountRunningBalance ?? 0;
        }

        public async Task<decimal> GetLastLeasePaymentRunningBalanceAsync(int leaseId)
        {
            var lastLeasePayment = await GetAll()
                                        .Where(p => p.LeaseId == leaseId)
                                        .OrderByDescending(p => p.CreatedDate)
                                        .FirstOrDefaultAsync();

            return lastLeasePayment?.LeaseRunningBalance ?? 0;
        }
    }
}
