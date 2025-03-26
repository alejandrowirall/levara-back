using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.Plaid.GetByGrid;

public class GetTransactionByGridQueryHandler : IQueryHandler<GetTransactionByGridQuery, PagedList<GetTransactionByGridQueryResponse>>
{
    private readonly IPlaidRepository _plaidRepository;
    public GetTransactionByGridQueryHandler(IPlaidRepository plaidRepository)
    {
        _plaidRepository = plaidRepository;
    }

    public async Task<OperationResult<PagedList<GetTransactionByGridQueryResponse>>> Handle(GetTransactionByGridQuery query)
    {
        var plaidTransactionQuery = _plaidRepository.GetAll();

        if (query.OwnerId.HasValue)
            plaidTransactionQuery = plaidTransactionQuery.Where(p => p.OwnerBankAccount.OwnerId == query.OwnerId!.Value);

        if (query.BankAccountId.HasValue)
            plaidTransactionQuery = plaidTransactionQuery.Where(p => p.OwnerBankAccount.Id == query.BankAccountId!.Value);

        if (query.DateFrom.HasValue)
            plaidTransactionQuery = plaidTransactionQuery.Where(p => p.Date >= query.DateFrom!.Value);

        if (query.DateTo.HasValue)
            plaidTransactionQuery = plaidTransactionQuery.Where(p => p.Date <= query.DateTo!.Value);

        if (query.Status.HasValue)
            plaidTransactionQuery = plaidTransactionQuery.Where(p => p.Status == query.Status!.Value);

        var paymenyQueryResponse = plaidTransactionQuery.OrderByDescending(p => p.Date)
                                                        .Select(p => new GetTransactionByGridQueryResponse(p));

        var response = await _plaidRepository.ToListPagedAsync(paymenyQueryResponse, query.PageNumber!.Value, query.PageSize!.Value);

        return OperationResult<PagedList<GetTransactionByGridQueryResponse>>.SuccessResult(response);
    }
}


