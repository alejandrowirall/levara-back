
using Boilerplate.Domain.Models;

namespace Boilerplate.Application.OwnersBankAccounts.GetByGrid;

public class GetOwnerBankAccountsByGridQueryResponse
{
    public GetOwnerBankAccountsByGridQueryResponse(OwnerBankAccount ownerBankAccount)
    {
        Id = ownerBankAccount.Id;
        BankName = ownerBankAccount.BankName;
        AccountNumberMasked = ownerBankAccount.AccountNumberMasked;
        PlaidAccountId = ownerBankAccount.PlaidAccountId;
    }
    public int Id { get; }

    public string BankName { get; set; }

    public string AccountNumberMasked { get; set; }

    public string PlaidAccountId { get; set; }

}