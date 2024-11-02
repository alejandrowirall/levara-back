
using Boilerplate.Domain.Models;

namespace Boilerplate.Application.OwnersBankAccounts.GetForUpdate;

public class GetOwnerBankAccountForUpdateQueryResponse
{
    public GetOwnerBankAccountForUpdateQueryResponse(OwnerBankAccountUpdateQueryResponse ownerBankAccount)
    {
        OwnerBankAccount = ownerBankAccount;
    }

    public OwnerBankAccountUpdateQueryResponse OwnerBankAccount { get; }
}

public class OwnerBankAccountUpdateQueryResponse
{
    public OwnerBankAccountUpdateQueryResponse(OwnerBankAccount ownerBankAccount)
    {
        Id = ownerBankAccount.Id;
        BankName = ownerBankAccount.BankName;
        AccountNumberMasked = ownerBankAccount.AccountNumberMasked;
        PlaidAccountId = ownerBankAccount.PlaidAccountId;
    }
    public int Id { get; }

    public string BankName { get; }

    public string AccountNumberMasked { get; }

    public string PlaidAccountId { get;}

}
