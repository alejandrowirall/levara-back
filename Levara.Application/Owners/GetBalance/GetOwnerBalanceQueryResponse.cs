using Levara.Domain.Models;
using Levara.Shared.Extensions;

namespace Levara.Application.Owners.GetBalance;

public class GetOwnerBalanceQueryResponse
{
    public GetOwnerBalanceQueryResponse(OwnerCard owner,
        IEnumerable<PaymentGrid> lastPayments,
        IEnumerable<PropertyBalanceGrid> propertyBalances)
    {
        Owner = owner;
        LastPayments = lastPayments;
        PropertyBalances = propertyBalances;
    }
   

    public OwnerCard Owner { get; }

    public IEnumerable<PaymentGrid> LastPayments { get; }

    public IEnumerable<PropertyBalanceGrid> PropertyBalances { get; }

}

public class PropertyBalanceGrid
{
    public PropertyBalanceGrid(Property property)
    {
        Id = property.Id;
        Number = property.Number;
        Address = $"{property.Address.Street} {property.Address.Number}";
        City = $"{property.Address.City}, {property.Address.State}";
        Balance = 0;
    }

    public int Id { get; }

    public int Number { get; }

    public string Address { get; }

    public string City { get; }

    public decimal Balance { get; set; }
}

public class OwnerCard
{
    public OwnerCard(Owner owner, decimal balance)
    {
        Id = owner.Id;
        Surname = owner.Surname;
        Name = owner.Name;
        Identification = $"{EnumExtensions.GetEnumDescription(owner.IdentificationType)}: {owner.Identification}";
        Balance = balance;
    }

    public int Id { get; }
    public string Surname { get; }

    public string Name { get; }
    public string Identification { get; }
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
