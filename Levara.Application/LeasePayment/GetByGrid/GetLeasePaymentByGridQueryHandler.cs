
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.LeasesPayment.GetByGrid;

public class GetLeasePaymentByGridQueryHandler : IQueryHandler<GetLeasePaymentByGridQuery, PagedList<GetLeasePaymentByGridQueryResponse>>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly ILeasePaymentRepository _leasePaymentRepository;
    public GetLeasePaymentByGridQueryHandler(ITransactionRepository transactionRepository, ILeasePaymentRepository leasePaymentRepository) 
    {
        _transactionRepository = transactionRepository;
        _leasePaymentRepository = leasePaymentRepository;
    }
    public async Task<OperationResult<PagedList<GetLeasePaymentByGridQueryResponse>>> Handle(GetLeasePaymentByGridQuery query)
    {

        var transactionQuery = _leasePaymentRepository.GetAll()
                                               .Where(t => t.Lease.PropertyId == query.PropertyId!.Value || (t.Lease.OwnerId == query.OwnerId!.Value))
                                               .OrderByDescending(p => p.CreatedDate)
                                               .Select(p => new GetLeasePaymentByGridQueryResponse(p));

        var response = await _transactionRepository.ToListPagedAsync(transactionQuery, query.PageNumber!.Value, query.PageSize!.Value);


        return OperationResult<PagedList<GetLeasePaymentByGridQueryResponse>>.SuccessResult(response);

    }
}


