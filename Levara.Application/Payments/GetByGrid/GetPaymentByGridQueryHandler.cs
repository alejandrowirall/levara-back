
using Levara.Domain.DAL.Repositories;
using Levara.Domain.Models;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;

namespace Levara.Application.Payments.GetByGrid;

public class GetPaymentByGridQueryHandler : IQueryHandler<GetPaymentByGridQuery, PagedList<GetPaymentByGridQueryResponse>>
{
    private readonly IPaymentRepository _paymentRepository;
    public GetPaymentByGridQueryHandler(IPaymentRepository paymentRepository) 
    {
        _paymentRepository = paymentRepository;
    }
    public async Task<OperationResult<PagedList<GetPaymentByGridQueryResponse>>> Handle(GetPaymentByGridQuery query)
    {

        var paymentQuery = _paymentRepository.GetAllFull();

        if (query.OwnerId.HasValue)
            paymentQuery = paymentQuery.Where(p => p.Property.OwnerId == query.OwnerId!.Value);

        if (query.PropertyId.HasValue)
            paymentQuery = paymentQuery.Where(p => p.PropertyId == query.PropertyId!.Value);

        if (query.DateFrom.HasValue)
            paymentQuery = paymentQuery.Where(p => p.Date >= query.DateFrom!.Value);

        if (query.DateTo.HasValue)
            paymentQuery = paymentQuery.Where(p => p.Date <= query.DateTo!.Value);

        if (query.Type.HasValue)
            paymentQuery = paymentQuery.Where(p => p.Type == query.Type!.Value);

        if (query.PaymentMethod.HasValue)
            paymentQuery = paymentQuery.Where(p => p.PaymentMethod == query.PaymentMethod!.Value);

        var paymenyQueryResponse = paymentQuery.OrderByDescending(p => p.Date)
                                               .Select(p => new GetPaymentByGridQueryResponse(p));

        var response = await _paymentRepository.ToListPagedAsync(paymenyQueryResponse, query.PageNumber!.Value, query.PageSize!.Value);


        return OperationResult<PagedList<GetPaymentByGridQueryResponse>>.SuccessResult(response);

    }
}


