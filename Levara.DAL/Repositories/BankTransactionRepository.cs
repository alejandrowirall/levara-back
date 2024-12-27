using Levara.Domain.Contexts;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levara.DAL.Repositories
{
    public class BankTransactionRepository : Repository<BankTransaction>, IBankTransactionRepository
    {
        public BankTransactionRepository(UnitOfWork unitOfWork,
        IUserContext userContext) : base(unitOfWork, userContext)
        {

        }
    }
}
