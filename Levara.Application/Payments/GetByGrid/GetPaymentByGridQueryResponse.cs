using Levara.Domain.Models;
using Levara.Shared.Extensions;

namespace Levara.Application.Payments.GetByGrid;

public class GetPaymentByGridQueryResponse
{
    public GetPaymentByGridQueryResponse(Payment payment)
    {
        Id = payment.Id;
        Description = payment.Description;
        PropertyDesc = $"{payment.Property.Number}-{payment.Property.Address.Street}, {payment.Property.Address.City}, {payment.Property.Address.State}";
        Date = payment.Date;
        TypeDesc = EnumExtensions.GetEnumDescription(payment.Type);
        PaymentMethodDesc = EnumExtensions.GetEnumDescription(payment.PaymentMethod);
        BankName = payment.OwnerBankAccount?.BankName;
        Amount = payment.Amount;    
    }
    public int Id { get; }
    public string PropertyDesc { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public string TypeDesc { get; set; }
    public string PaymentMethodDesc { get; set; }
    public string? BankName { get; set; }
    public decimal Amount { get; set; }
}