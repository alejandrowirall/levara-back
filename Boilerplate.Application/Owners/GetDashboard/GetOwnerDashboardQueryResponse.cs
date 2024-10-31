
using Boilerplate.Domain.Models;

namespace Boilerplate.Application.Owners.GetDashboard;

public class GetOwnerDashboardQueryResponse
{
    public GetOwnerDashboardQueryResponse(IEnumerable<PropertyCard> properties,
        IEnumerable<OwnerBankAccountGrid> ownerBankAccounts)
    {
        Properties = properties;
        OwnerBankAccounts = ownerBankAccounts;
    }
    
    public IEnumerable<PropertyCard> Properties { get; }

    public IEnumerable<OwnerBankAccountGrid> OwnerBankAccounts { get; }
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
