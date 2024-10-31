
using Boilerplate.Domain.Contexts;
using Boilerplate.Domain.DAL.Repositories;
using Boilerplate.Domain.Models;

namespace Boilerplate.DAL.Repositories;

public class OwnerBankAccountRepository : Repository<OwnerBankAccount>, IOwnerBankAccountRepository
{
    public OwnerBankAccountRepository(UnitOfWork unitOfWork, 
        IUserContext userContext) : base(unitOfWork, userContext)
    {

    }
}
