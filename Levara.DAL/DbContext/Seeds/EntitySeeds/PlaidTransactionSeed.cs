using Levara.Domain.Models;

namespace Levara.DAL.DbContext.Seeds.EntitySeeds
{
    public class PlaidTransactionSeed : SeedBase
    {
        protected override void Execute()
        {
            DateTime datatimeApp = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            List<PlaidTransaction> plaidTransactions = new();

            for (int i = 1; i < 13; i++)
            {
                PlaidTransaction uberPlaidTrans = new()
                {
                    Id = plaidTransactions.Count + 1,
                    TransactionId = Guid.NewGuid().ToString(),
                    Date = new DateTime(2024, i, 2, 0, 0, 0, DateTimeKind.Utc),
                    Description = $"Uber 0630{i}5 SF**POOL**",
                    Amount = -5.4m,
                    Status = Domain.Enum.PlaidTransactionStatus.Created,
                    OwnerBankAccountId = 1,
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                };

                plaidTransactions.Add(uberPlaidTrans);

                PlaidTransaction leasePlaidTrans = new()
                {
                    Id = plaidTransactions.Count + 1,
                    TransactionId = Guid.NewGuid().ToString(),
                    Date = new DateTime(2024, i, 6, 0, 0, 0, DateTimeKind.Utc),
                    Description = $"Payment rent 1/{i}/2024",
                    Amount = 1500,
                    Status = Domain.Enum.PlaidTransactionStatus.Created,
                    OwnerBankAccountId = 1,
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                };

                plaidTransactions.Add(leasePlaidTrans);

                PlaidTransaction maintenancePlaidTrans = new()
                {
                    Id = plaidTransactions.Count + 1,
                    TransactionId = Guid.NewGuid().ToString(),
                    Date = new DateTime(2024, i, 11, 0, 0, 0, DateTimeKind.Utc),
                    Description = $"Payment maintenance charge 2/{i}/2024",
                    Amount = -800,
                    Status = Domain.Enum.PlaidTransactionStatus.Created,
                    OwnerBankAccountId = 1,
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                };

                plaidTransactions.Add(maintenancePlaidTrans);

                PlaidTransaction expensePlaidTrans = new()
                {
                    Id = plaidTransactions.Count + 1,
                    TransactionId = Guid.NewGuid().ToString(),
                    Date = new DateTime(2024, i, 12, 0, 0, 0, DateTimeKind.Utc),
                    Description = $"Payment cleaning charge 3/{i}/2024",
                    Amount = -150,
                    Status = Domain.Enum.PlaidTransactionStatus.Created,
                    OwnerBankAccountId = 1,
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                };

                plaidTransactions.Add(expensePlaidTrans);

            }

            this.modelBuilder.Entity<PlaidTransaction>().HasData(plaidTransactions);
        }
    }
}
