
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.Transactions.GetByGrid;

public class GetTransactionsByGridQueryHandler : IQueryHandler<GetTransactionsByGridQuery, PagedList<GetTransactionsByGridQueryResponse>>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly ILeaseRepository _leaseRepository;
    public GetTransactionsByGridQueryHandler(ITransactionRepository transactionRepository, ILeaseRepository leaseRepository) 
    {
        _transactionRepository = transactionRepository;
        _leaseRepository=leaseRepository;
    }
    public async Task<OperationResult<PagedList<GetTransactionsByGridQueryResponse>>> Handle(GetTransactionsByGridQuery query)
    {

        var transactionQuery = _transactionRepository.GetAllWithProperty()
                                               .Where(t => t.PropertyId == query.PropertyId!.Value || (t.Property.OwnerId == query.OwnerId!.Value))
                                               .OrderByDescending(p => p.CreatedDate)
                                               .Select(p => new GetTransactionsByGridQueryResponse(p));

       


        var response = await _transactionRepository.ToListPagedAsync(transactionQuery, query.PageNumber!.Value, query.PageSize!.Value);


        return OperationResult<PagedList<GetTransactionsByGridQueryResponse>>.SuccessResult(response);

    }
}


