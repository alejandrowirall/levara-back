
using Levara.Application.PaymentMethods.Get;
using Levara.Domain.Enum;
using Levara.Shared.Domain.Bus.Queries;
using Levara.Shared.Domain.Models;
using Levara.Shared.Extensions;
using Levara.Shared.Results;

namespace Levara.Application.LeasesCharges.GetByGrid;

public class GetPaymentMethodQueryHandler : IQueryHandler<GetPaymentMethodQuery, IEnumerable<GetPaymentMethodQueryResponse>>
{
    public GetPaymentMethodQueryHandler() 
    {
    }
    public Task<OperationResult<IEnumerable<GetPaymentMethodQueryResponse>>> Handle(GetPaymentMethodQuery query)
    {
        List<ListModel> paymentMethods = EnumExtensions.ToListModel<PaymentMethod>();
        var response = paymentMethods.Select(pm => new GetPaymentMethodQueryResponse(pm));

        return Task.FromResult(OperationResult<IEnumerable<GetPaymentMethodQueryResponse>>.SuccessResult(response));
    }
}


