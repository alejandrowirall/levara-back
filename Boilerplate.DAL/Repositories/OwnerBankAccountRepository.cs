
using Levara.Domain.Contexts;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;

namespace Levara.DAL.Repositories;

public class OwnerBankAccountRepository : Repository<OwnerBankAccount>, IOwnerBankAccountRepository
{
    public OwnerBankAccountRepository(UnitOfWork unitOfWork, 
        IUserContext userContext) : base(unitOfWork, userContext)
    {

    }
}
