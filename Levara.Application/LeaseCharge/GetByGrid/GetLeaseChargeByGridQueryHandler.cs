
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.LeasesCharges.GetByGrid;

public class GetLeaseChargeByGridQueryHandler : IQueryHandler<GetLeaseChargeByGridQuery, PagedList<GetLeaseChargeByGridQueryResponse>>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly ILeaseChargeRepository _leaseChargeRepository;
    public GetLeaseChargeByGridQueryHandler(ITransactionRepository transactionRepository, ILeaseChargeRepository leaseChargeRepository) 
    {
        _transactionRepository = transactionRepository;
        _leaseChargeRepository = leaseChargeRepository;
    }
    public async Task<OperationResult<PagedList<GetLeaseChargeByGridQueryResponse>>> Handle(GetLeaseChargeByGridQuery query)
    {

        var transactionQuery = _leaseChargeRepository.GetAllFull()
                                               .Where(t => t.Lease.PropertyId == query.PropertyId!.Value || (t.Lease.OwnerId == query.OwnerId!.Value))
                                               .OrderByDescending(p => p.CreatedDate)
                                               .Select(p => new GetLeaseChargeByGridQueryResponse(p));

        var response = await _transactionRepository.ToListPagedAsync(transactionQuery, query.PageNumber!.Value, query.PageSize!.Value);


        return OperationResult<PagedList<GetLeaseChargeByGridQueryResponse>>.SuccessResult(response);

    }
}


