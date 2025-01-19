
using Levara.Application.Leases.GetForCreate;
using Levara.Application.Leases.GetForUpdate;
using Levara.Application.Leases.Update;
using Levara.Application.OwnersBankAccounts.GetForUpdate;
using Levara.Application.Plaid.GetPublicToken;
using Levara.Application.Plaid.GetTransactionsOwnerFromPlaid;
using Levara.Domain.DAL;
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.ExternalService.Plaid;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Domain.Models;
using Levara.Shared.Results;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace Levara.Application.Plaid.GetTransactionsOwner;

public class GetTransactionsOwnerQueryHandler : IQueryHandler<GetTransactionsOwnerQuery, List<GetTransactionsOwnerQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOwnerBankAccountRepository _ownerBankAccountRepository;
    private readonly IPlaidRepository _plaidRepository;
    public GetTransactionsOwnerQueryHandler(IUnitOfWork unitOfWork, IOwnerBankAccountRepository ownerBankAccountRepository, IPlaidRepository plaidRepository)
    {
        _unitOfWork = unitOfWork;

        _ownerBankAccountRepository = ownerBankAccountRepository;
        _plaidRepository = plaidRepository;
    }
    public async Task<OperationResult<List<GetTransactionsOwnerQueryResponse>>> Handle(GetTransactionsOwnerQuery query)
    {
        var bankAccountQuery = _ownerBankAccountRepository.GetAll()
                                               .Where(p => p.OwnerId == query.OwnerId);

        var bankAccountIds = bankAccountQuery.Select(b => b.Id).ToList();

        // Aplicar el filtro como un "IN" usando Contains
        var responseFunction = _plaidRepository.GetAll()
                                .Where(x => bankAccountIds.Contains(x.OwnerBankAccountId) &&
                                (!query.Status.HasValue || x.Status == query.Status))
                                .Select(l => new GetTransactionsOwnerQueryResponse(l))
                                .ToList();
        
        return OperationResult<List<GetTransactionsOwnerQueryResponse>>.SuccessResult(responseFunction);


    }
}


