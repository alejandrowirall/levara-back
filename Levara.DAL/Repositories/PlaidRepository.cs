using Levara.Domain.Contexts;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Levara.DAL.Repositories;

public class PlaidRepository : Repository<PlaidTransaction>, IPlaidRepository
{
    public PlaidRepository(UnitOfWork unitOfWork,
    IUserContext userContext) : base(unitOfWork, userContext)
    {

    }

    public IQueryable<PlaidTransaction> GetAllWithOwnerBankAccount()
    {
        return GetAll().Include(p => p.OwnerBankAccount);
    }

    public IQueryable<PlaidTransaction> GetAllWithOwner()
    {
        return GetAll().Include(p => p.OwnerBankAccount).ThenInclude(oba => oba.Owner);
    }
}
