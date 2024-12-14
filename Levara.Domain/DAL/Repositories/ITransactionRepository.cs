using Levara.Domain.Models;

namespace Levara.Domain.DAL.Repositories;

public interface ITransactionRepository : IRepository<Transaction>
{
    IQueryable<Transaction> GetAllWithProperty();
}
