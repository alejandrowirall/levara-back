
using Levara.Shared.Domain.Models;

namespace Levara.Application.PaymentMethods.Get;

public class GetPaymentMethodQueryResponse
{
    public GetPaymentMethodQueryResponse(ListModel paymentMethod)
    {
        Id = paymentMethod.Id;
        Description = paymentMethod.Text;
    }

    public int Id { get; set; }
    public string Description { get; set; }
}
