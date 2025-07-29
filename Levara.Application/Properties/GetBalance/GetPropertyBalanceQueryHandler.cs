using Levara.Domain.DAL.Repositories;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace Levara.Application.Properties.GetBalance;

public class GetOwnerBalanceQueryHandler : IQueryHandler<GetPropertyBalanceQuery, GetPropertyBalanceQueryResponse>
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IPropertyRepository _propertyRepository;
    public GetOwnerBalanceQueryHandler(IPaymentRepository paymentRepository,
        IPropertyRepository propertyRepository) 
    {
        _paymentRepository = paymentRepository;
        _propertyRepository = propertyRepository;
    }
    public async Task<OperationResult<GetPropertyBalanceQueryResponse>> Handle(GetPropertyBalanceQuery query)
    {
        var propertyQuery =  _propertyRepository.GetAllWithAddress()
                                                .Where(p => p.Id == query.PropertyId!.Value && p.OwnerId == query.OwnerId!.Value);

        if (query.OwnerId.HasValue)
            propertyQuery = propertyQuery.Where(p => p.OwnerId == query.OwnerId!.Value);

        var property = await _propertyRepository.FirstOrDefaultAsync(propertyQuery);
        if (property == null)
            return OperationResult<GetPropertyBalanceQueryResponse>.ErrorResult(new ErrorDetails(404, $"Property with id {query.PropertyId!.Value} not found."));


        var propertyBalance = await _paymentRepository.GetAll()
                                                   .Where(p => p.PropertyId == query.PropertyId!.Value)
                                                   .OrderByDescending(p => p.CreatedDate)
                                                   .Select(p => p.RunningBalance)
                                                   .FirstOrDefaultAsync();

        var lastPaymentsQuery = _paymentRepository.GetAllWithOwnerBankAccount()
                                                  .Where(p => p.PropertyId == query.PropertyId!.Value)
                                                  .OrderByDescending(bt => bt.Date)
                                                  .Take(3);

        var lastPayments = await _paymentRepository.ToListAsync(lastPaymentsQuery);

        var lastPayment = lastPayments.FirstOrDefault();

        PropertyCard propertyCard = new (property, propertyBalance);

        var paymentsGrid = lastPayments.Select(p => new PaymentGrid(p));

        GetPropertyBalanceQueryResponse response = new(property.OwnerId, propertyCard, paymentsGrid);
        
        return OperationResult<GetPropertyBalanceQueryResponse>.SuccessResult(response);

    }
}
