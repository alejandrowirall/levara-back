using Levara.Domain.Models;
using Levara.Shared.Extensions;

namespace Levara.Application.Properties.GetBalance;

public class GetPropertyBalanceQueryResponse
{
    public GetPropertyBalanceQueryResponse(PropertyCard property,
        IEnumerable<PaymentGrid> lastPayments)
    {
        Property = property;
        LastPayments = lastPayments;
    }
   

    public PropertyCard Property { get; }

    public IEnumerable<PaymentGrid> LastPayments { get; }

}


public class PropertyCard
{
    public PropertyCard(Property property, decimal balance)
    {
        Id = property.Id;
        Number = property.Number;
        Title = $"{property.Address.Street} {property.Address.Number}";
        SubTitle = $"{property.Address.City}, {property.Address.State}";
        Balance = balance;
    }

    public int Id { get; }
    public int Number { get; set; }
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public decimal Balance { get; }
}


public class PaymentGrid
{
    public PaymentGrid(Payment payment)
    {
        Id = payment.Id;
        Description = payment.Description;
        BankName = payment.OwnerBankAccount?.BankName;
        AccountNumber = payment.OwnerBankAccount?.AccountNumberMasked;
        PaymentMethod = EnumExtensions.GetEnumDescription(payment.PaymentMethod);
        Date = payment.Date;
        Amount = payment.Amount;
    }
    public int Id { get; }
    
    public string? BankName { get; }
    public string? AccountNumber { get; }

    public string PaymentMethod { get; }
    public DateTime Date { get; }
    public string Description { get; }
    public decimal Amount { get; }
}
