
using Boilerplate.Domain.Models;

namespace Boilerplate.Application.Owners.GetDashboard;

public class GetOwnerDashboardQueryResponse
{
    public GetOwnerDashboardQueryResponse(IEnumerable<PropertyCard> properties,
        IEnumerable<OwnerBankAccountGrid> ownerBankAccounts,
        IEnumerable<RentPaymentNotificationGrid> rentPaymentsNotifications,
        IEnumerable<ImportantNotificationGrid> importantNotifications)
    {
        Properties = properties;
        OwnerBankAccounts = ownerBankAccounts;
        RentPaymentsNotifications = rentPaymentsNotifications;
        ImportantNotifications = importantNotifications;
    }
    
    public IEnumerable<PropertyCard> Properties { get; }

    public IEnumerable<OwnerBankAccountGrid> OwnerBankAccounts { get; }

    public IEnumerable<RentPaymentNotificationGrid> RentPaymentsNotifications { get; }

    public IEnumerable<ImportantNotificationGrid> ImportantNotifications { get; }

}

public class PropertyCard
{
    public PropertyCard(Property property)
    {
        Id = property.Id;
        Title = $"Property {property.Number}";
        Description = $"{property.Address.Street} {property.Address.Number}, {property.Address.City}, {property.Address.State}";
        Footer = $"$12,426";
    }

    public int Id { get; }

    public string Title { get; }

    public string Description { get; }

    public string Footer { get; }
}

public class OwnerBankAccountGrid
{
    public OwnerBankAccountGrid(OwnerBankAccount ownerBankAccount)
    {
        Id = ownerBankAccount.Id;
        Description = $"{ownerBankAccount.BankName} - {ownerBankAccount.AccountNumberMasked}";
    }

    public int Id { get; }

    public string Description { get; }
}

public class RentPaymentNotificationGrid
{

    public int Id { get; set; }

    public string Property { get; set; }

    public DateTime DueDate { get; set; }

    public string Status { get; set; }
}

public class ImportantNotificationGrid
{

    public int Id { get; set; }

    public string Property { get; set; }

    public DateTime Date { get; set; }

    public string Detail { get; set; }
}
