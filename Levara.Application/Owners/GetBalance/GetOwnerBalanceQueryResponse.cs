using Levara.Domain.Models;
using Levara.Shared.Extensions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Levara.Application.Owners.GetBalance;

public class GetOwnerBalanceQueryResponse
{
    public GetOwnerBalanceQueryResponse(OwnerCard owner,
        IEnumerable<BankTransactionGrid> lastBankTransactions,
        IEnumerable<PropertyBalanceGrid> propertyBalances)
    {
        Owner = owner;
        LastBankTransactions = lastBankTransactions;
        PropertyBalances = propertyBalances;
    }
   

    public OwnerCard Owner { get; }

    public IEnumerable<BankTransactionGrid> LastBankTransactions { get; }

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
        Balance = 0.00;
    }

    public int Id { get; }

    public int Number { get; }

    public string Address { get; }

    public string City { get; }

    public double Balance { get; set; }
}

public class OwnerCard
{
    public OwnerCard(Owner owner, string balance)
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
    public string Balance { get; }
}

public class OwnerBankAccountCard
{
    public OwnerBankAccountCard(OwnerBankAccount ownerBankAccount, string balance)
    {
        Id = ownerBankAccount.Id;
        BankName = ownerBankAccount.BankName;
        Description = $"{ownerBankAccount.BankName} - {ownerBankAccount.AccountNumberMasked}";
        Balance = balance;
    }

    public int Id { get; }
    public string BankName { get; }
    public string Description { get; }
    public string Balance { get; }
}

public class BankTransactionGrid
{
    public BankTransactionGrid(BankTransaction bankTransaction)
    {
        Id = bankTransaction.Id;
        Description = bankTransaction.Description;
        BankName = bankTransaction.OwnerBankAccount.BankName;
        AccountNumber = bankTransaction.OwnerBankAccount.AccountNumberMasked;
        Date = bankTransaction.Date;
        Amount = bankTransaction.Amount!.Value;
    }
    public int Id { get; }
    
    public string BankName { get; }
    public string AccountNumber { get; }
    public DateTime Date { get; }
    public string Description { get; }
    public double Amount { get; }
}


public class RentPaymentNotificationGrid
{
    public RentPaymentNotificationGrid(RentPaymentNotification rentPaymentNotification)
    {
        Id = rentPaymentNotification.Id;
        Property = rentPaymentNotification.Property;
        DueDate = rentPaymentNotification.DueDate;
        Status = rentPaymentNotification.Status;
    }

    public int Id { get; set; }

    public string Property { get; set; }

    public DateTime DueDate { get; set; }

    public string Status { get; set; }
}

public class ImportantNotificationGrid
{
    public ImportantNotificationGrid(PropertyNotification propertyNotification)
    {
        Id = propertyNotification.Id;
        Property = propertyNotification.Property;
        Date = propertyNotification.Date;
        Detail = propertyNotification.Detail;
    }

    public int Id { get; set; }

    public string Property { get; set; }

    public DateTime Date { get; set; }

    public string Detail { get; set; }
}
