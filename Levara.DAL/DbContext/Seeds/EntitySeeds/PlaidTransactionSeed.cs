using Levara.Domain.Models;

namespace Levara.DAL.DbContext.Seeds.EntitySeeds
{
    public class PlaidTransactionSeed : SeedBase
    {
        protected override void Execute()
        {
            DateTime datatimeApp = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            var plaidTransactions = new List<PlaidTransaction>
            {
                new PlaidTransaction
                {
                    Id = 1,
                    TransactionId = "rarm3XavAqHjkJoldNGdUa6KG1MqNeU71N6BM",
                    Date = new DateTime(2025, 1, 13, 0, 0, 0, DateTimeKind.Utc),
                    Description = "Uber 063015 SF**POOL**",
                    Amount = 5.4,
                    Status = Domain.Enum.PlaidTransactionStatus.Created,
                    OwnerBankAccountId = 1,
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                },
                new PlaidTransaction
                {
                    Id = 2,
                    TransactionId = "rarm3XavAqHjkJoldNGdUa6KG1MqNeU71N6CM",
                    Date = new DateTime(2024, 1, 6, 0, 0, 0, DateTimeKind.Utc),
                    Description = "Payment rent 1/1/2024",
                    Amount = 1500.00,
                    Status = Domain.Enum.PlaidTransactionStatus.Created,
                    OwnerBankAccountId = 1,
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                },
                new PlaidTransaction
                {
                    Id = 3,
                    TransactionId = "rarm3XavAqHjkJoldNGdUa6KG1MqNeU71N6DM",
                    Date = new DateTime(2024, 2, 6, 0, 0, 0, DateTimeKind.Utc),
                    Description = "Payment rent 1/2/2024",
                    Amount = 1500.00,
                    Status = Domain.Enum.PlaidTransactionStatus.Created,
                    OwnerBankAccountId = 1,
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                },
                new PlaidTransaction
                {
                    Id = 4,
                    TransactionId = "rarm3XavAqHjkJoldNGdUa6KG1MqNeU71N6DM",
                    Date = new DateTime(2024, 3, 6, 0, 0, 0, DateTimeKind.Utc),
                    Description = "Payment rent 1/3/2024",
                    Amount = 1500.00,
                    Status = Domain.Enum.PlaidTransactionStatus.Created,
                    OwnerBankAccountId = 1,
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                },
                new PlaidTransaction
                {
                    Id = 5,
                    TransactionId = "rarm3XavAqHjkJoldNGdUa6KG1MqNeU71N6EM",
                    Date = new DateTime(2024, 4, 6, 0, 0, 0, DateTimeKind.Utc),
                    Description = "Payment rent 1/4/2024",
                    Amount = 1500.00,
                    Status = Domain.Enum.PlaidTransactionStatus.Created,
                    OwnerBankAccountId = 1,
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                },
                new PlaidTransaction
                {
                    Id = 6,
                    TransactionId = "rarm3XavAqHjkJoldNGdUa6KG1MqNeU71N6FM",
                    Date = new DateTime(2024, 5, 6, 0, 0, 0, DateTimeKind.Utc),
                    Description = "Payment rent 1/5/2024",
                    Amount = 1500.00,
                    Status = Domain.Enum.PlaidTransactionStatus.Created,
                    OwnerBankAccountId = 1,
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                },
                new PlaidTransaction
                {
                    Id = 7,
                    TransactionId = "rarm3XavAqHjkJoldNGdUa6KG1MqNeU71N6GM",
                    Date = new DateTime(2024, 6, 6, 0, 0, 0, DateTimeKind.Utc),
                    Description = "Payment rent 1/6/2024",
                    Amount = 1500.00,
                    Status = Domain.Enum.PlaidTransactionStatus.Created,
                    OwnerBankAccountId = 1,
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                },
                new PlaidTransaction
                {
                    Id = 8,
                    TransactionId = "rarm3XavAqHjkJoldNGdUa6KG1MqNeU71N6HM",
                    Date = new DateTime(2024, 7, 6, 0, 0, 0, DateTimeKind.Utc),
                    Description = "Payment rent 1/7/2024",
                    Amount = 1500.00,
                    Status = Domain.Enum.PlaidTransactionStatus.Created,
                    OwnerBankAccountId = 1,
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                },
                new PlaidTransaction
                {
                    Id = 9,
                    TransactionId = "rarm3XavAqHjkJoldNGdUa6KG1MqNeU71N6IM",
                    Date = new DateTime(2024, 8, 6, 0, 0, 0, DateTimeKind.Utc),
                    Description = "Payment rent 1/8/2024",
                    Amount = 1500.00,
                    Status = Domain.Enum.PlaidTransactionStatus.Created,
                    OwnerBankAccountId = 1,
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                },
                new PlaidTransaction
                {
                    Id = 10,
                    TransactionId = "rarm3XavAqHjkJoldNGdUa6KG1MqNeU71N6IM",
                    Date = new DateTime(2024, 9, 6, 0, 0, 0, DateTimeKind.Utc),
                    Description = "Payment rent 1/9/2024",
                    Amount = 1500.00,
                    Status = Domain.Enum.PlaidTransactionStatus.Created,
                    OwnerBankAccountId = 1,
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                },
                new PlaidTransaction
                {
                    Id = 11,
                    TransactionId = "rarm3XavAqHjkJoldNGdUa6KG1MqNeU71N6IM",
                    Date = new DateTime(2024, 10, 6, 0, 0, 0, DateTimeKind.Utc),
                    Description = "Payment rent 1/10/2024",
                    Amount = 1500.00,
                    Status = Domain.Enum.PlaidTransactionStatus.Created,
                    OwnerBankAccountId = 1,
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                },
                new PlaidTransaction
                {
                    Id = 12,
                    TransactionId = "rarm3XavAqHjkJoldNGdUa6KG1MqNeU71N6IM",
                    Date = new DateTime(2024, 11, 6, 0, 0, 0, DateTimeKind.Utc),
                    Description = "Payment rent 1/11/2024",
                    Amount = 1500.00,
                    Status = Domain.Enum.PlaidTransactionStatus.Created,
                    OwnerBankAccountId = 1,
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                },
                new PlaidTransaction
                {
                    Id = 13,
                    TransactionId = "rarm3XavAqHjkJoldNGdUa6KG1MqNeU71N6IM",
                    Date = new DateTime(2024, 12, 6, 0, 0, 0, DateTimeKind.Utc),
                    Description = "Payment rent 1/12/2024",
                    Amount = 1500.00,
                    Status = Domain.Enum.PlaidTransactionStatus.Created,
                    OwnerBankAccountId = 1,
                    CreatorId = 1,
                    CreatedDate = datatimeApp,
                    LastEditorId = 1,
                    LastEditedDate = datatimeApp,
                },

            };

            this.modelBuilder.Entity<PlaidTransaction>().HasData(plaidTransactions);
        }
    }
}
