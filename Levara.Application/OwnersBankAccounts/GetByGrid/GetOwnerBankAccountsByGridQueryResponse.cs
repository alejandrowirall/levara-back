
using Levara.Domain.Models;

namespace Levara.Application.OwnersBankAccounts.GetByGrid;

public class GetOwnerBankAccountsByGridQueryResponse
{
    public GetOwnerBankAccountsByGridQueryResponse(OwnerBankAccount ownerBankAccount)
    {
        Id = ownerBankAccount.Id;
        BankName = ownerBankAccount.BankName;
        AccountNumberMasked = ownerBankAccount.AccountNumberMasked;
        PlaidAccountId = ownerBankAccount.PlaidAccountId;
        LastUpdated = ownerBankAccount.LastEditedDate;
    }
    public int Id { get; }

    public string BankName { get; set; }

    public string AccountNumberMasked { get; set; }

    public DateTime LastUpdated { get; set; }

    public string PlaidAccountId { get; set; }

}