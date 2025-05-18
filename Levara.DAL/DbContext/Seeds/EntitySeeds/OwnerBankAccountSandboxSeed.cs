using Levara.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Levara.DAL.DbContext.Seeds.EntitySeeds;

public class OwnerBankAccountSandboxSeed : SeedBase
{
    protected override void Execute()
    {
        var userHasher = new PasswordHasher<ApplicationUser>();

        DateTime datatimeApp = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        List<OwnerBankAccount> accountsToAdd = new List<OwnerBankAccount>();

        accountsToAdd.Add(new OwnerBankAccount
        {
            Id = 1,
            BankName = "Chase",
            AccountNumberMasked = "****0000",
            PlaidAccountId = "access-sandbox-9fd21743-09b8-4e9b-8f8c-26fb07c0b7c7",
            OwnerId = 1,
            CreatedDate = datatimeApp,
            LastEditedDate = datatimeApp,
            CreatorId = 1,
            LastEditorId = 1,
        });

        accountsToAdd.Add(new OwnerBankAccount
        {
            Id = 2,
            BankName = "Bank of America",
            AccountNumberMasked = "****0000",
            PlaidAccountId = "access-sandbox-2d239d6a-1de6-4d51-8094-d168e414fb62",
            OwnerId = 1,
            CreatedDate = datatimeApp,
            LastEditedDate = datatimeApp,
            CreatorId = 1,
            LastEditorId = 1,
        });

        accountsToAdd.Add(new OwnerBankAccount
        {
            Id = 3,
            BankName = "Citibank Online",
            AccountNumberMasked = "****0000",
            PlaidAccountId = "access-sandbox-73afb973-7579-4811-ae7b-f860eeaf02c1",
            OwnerId = 1,
            CreatedDate = datatimeApp,
            LastEditedDate = datatimeApp,
            CreatorId = 1,
            LastEditorId = 1,
        });

        accountsToAdd.Add(new OwnerBankAccount
        {
            Id = 4,
            BankName = "U.S. Bank",
            AccountNumberMasked = "****0000",
            PlaidAccountId = "access-sandbox-c965a93d-7f0d-4d90-9030-42eb6956d29b",
            OwnerId = 1,
            CreatedDate = datatimeApp,
            LastEditedDate = datatimeApp,
            CreatorId = 1,
            LastEditorId = 1,
        });

        accountsToAdd.Add(new OwnerBankAccount
        {
            Id = 5,
            BankName = "Capital One",
            AccountNumberMasked = "****0000",
            PlaidAccountId = "access-sandbox-f2f106c8-0ecb-4200-91d8-7e61d2e62a8b",
            OwnerId = 1,
            CreatedDate = datatimeApp,
            LastEditedDate = datatimeApp,
            CreatorId = 1,
            LastEditorId = 1,
        });

        accountsToAdd.Add(new OwnerBankAccount
        {
            Id = 6,
            BankName = "Wells Fargo",
            AccountNumberMasked = "****0000",
            PlaidAccountId = "access-sandbox-ad12184c-d3dc-4be9-92e2-9a36b6f5447b",
            OwnerId = 1,
            CreatedDate = datatimeApp,
            LastEditedDate = datatimeApp,
            CreatorId = 1,
            LastEditorId = 1,
        });

        this.modelBuilder.Entity<OwnerBankAccount>().HasData(accountsToAdd);
    }
}
