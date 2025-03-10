using Levara.Domain.Models;

namespace Levara.Domain.DAL.Repositories;

public interface IPaymentRepository : IRepository<Payment>
{
    IQueryable<Payment> GetAllWithOwnerBankAccount();

    IQueryable<Payment> GetAllWithProperty();

    IQueryable<Payment> GetAllFull();
}
