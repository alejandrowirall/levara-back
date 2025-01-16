using Levara.Domain.Models;
using Levara.Domain.Enum;
using Microsoft.AspNetCore.Identity;

namespace Levara.DAL.DbContext.Seeds.EntitySeeds;

public class TransactionSeed : SeedBase
{
    protected override void Execute()
    {
        var userHasher = new PasswordHasher<ApplicationUser>();

        DateTime datatimeApp = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        List<Transaction> transactions = new();
        List<TransactionApplication> transactionApplications = new();
        List<LeaseCharge> leaseCharges = new();
        List<LeasePayment> leasePayments = new();
        Transaction? lastTransaction = default;

        for (int i = 1; i < 13; i++)
        {
            lastTransaction = transactions.OrderByDescending(t => t.Id).FirstOrDefault();

            Transaction chargeTransaction = new()
            {
                Id = transactions.Count() + 1,
                Type = TransactionType.Lease,
                SubType = TransactionSubType.Charge,
                EntityId = 1,
                Date = new DateTime(2024, i, 2, 0, 0, 0, DateTimeKind.Utc),
                Description = $"Charge of rent {new DateTime(2024, i, i, 0, 0, 0, DateTimeKind.Utc).ToShortDateString()}",
                Amount = 1500,
                RunningBalance = i == 1 ? -1500 : lastTransaction!.RunningBalance - 1500,
                EntityRunningBalance = i == 1 ? -1500 : lastTransaction!.RunningBalance - 1500,
                PropertyId = 1,
                CreatorId = 1,
                CreatedDate = datatimeApp,
                LastEditorId = 1,
                LastEditedDate = datatimeApp,
            };

            transactions.Add(chargeTransaction);

            LeaseCharge leaseCharge = new()
            {
                Id = leaseCharges.Count() + 1,
                LeaseId = 1,
                TransactionId = chargeTransaction.Id,
                DueDate = new DateTime(2024, i, 10, 0, 0, 0, DateTimeKind.Utc),
                Status = LeaseChargeStatus.Unpaid,
                CreatorId = 1,
                CreatedDate = datatimeApp,
                LastEditorId = 1,
                LastEditedDate = datatimeApp,
            };

            leaseCharges.Add(leaseCharge);

            //if (i < 12)
            //{
                //    Transaction paymentTransaction = new()
                //    {
                //        Id = transactions.Count() + 1,
                //        Type = TransactionType.Lease,
                //        SubType = TransactionSubType.Payment,
                //        EntityId = 1,
                //        Date = new DateTime(2024, i, 5, 0, 0, 0, DateTimeKind.Utc),
                //        Description = $"Payment of rent {new DateTime(2024, i, 5, 0, 0, 0, DateTimeKind.Utc).ToShortDateString()}",
                //        Amount = 1500,
                //        RunningBalance = chargeTransaction!.RunningBalance + 1500,
                //        EntityRunningBalance = chargeTransaction!.RunningBalance + 1500,
                //        PropertyId = 1,
                //        CreatorId = 1,
                //        CreatedDate = datatimeApp,
                //        LastEditorId = 1,
                //        LastEditedDate = datatimeApp,
                //    };

                //    transactions.Add(paymentTransaction);

                //    LeasePayment leasePayment = new()
                //    {
                //        Id = leasePayments.Count() + 1,
                //        LeaseId = 1,
                //        TransactionId = paymentTransaction.Id,
                //        CreatorId = 1,
                //        CreatedDate = datatimeApp,
                //        LastEditorId = 1,
                //        LastEditedDate = datatimeApp,
                //    };

                //    leasePayments.Add(leasePayment);

                //    TransactionApplication transactionApplication = new()
                //    {
                //        Id = transactionApplications.Count() + 1,
                //        ChargeTransactionId = chargeTransaction.Id,
                //        PaymentTransactionId = paymentTransaction.Id,
                //        AppliedAmount = paymentTransaction.Amount,
                //        CreatorId = 1,
                //        CreatedDate = datatimeApp,
                //        LastEditorId = 1,
                //        LastEditedDate = datatimeApp,
                //        BankTransactionId = transactionApplications.Count() + 1,
                //    };

                //    transactionApplications.Add(transactionApplication);
            //}
        }

        lastTransaction = transactions.OrderByDescending(t => t.Id).FirstOrDefault();

        //Transaction chargeMaintenanceTransaction = new()
        //{
        //    Id = transactions.Count() + 1,
        //    Type = TransactionType.Maintenance,
        //    SubType = TransactionSubType.Charge,
        //    EntityId = 1,
        //    Date = new DateTime(2024, 12, 9, 0, 0, 0, DateTimeKind.Utc),
        //    Description = $"Charge of maintenance {new DateTime(2024, 12, 9, 0, 0, 0, DateTimeKind.Utc).ToShortDateString()}",
        //    Amount = 450,
        //    RunningBalance = lastTransaction!.RunningBalance - 450,
        //    EntityRunningBalance = -450,
        //    PropertyId = 1,
        //    CreatorId = 1,
        //    CreatedDate = datatimeApp,
        //    LastEditorId = 1,
        //    LastEditedDate = datatimeApp,
        //};

        //transactions.Add(chargeMaintenanceTransaction);

        this.modelBuilder.Entity<Transaction>().HasData(transactions);
        //this.modelBuilder.Entity<TransactionApplication>().HasData(transactionApplications);
        this.modelBuilder.Entity<LeaseCharge>().HasData(leaseCharges);
        //this.modelBuilder.Entity<LeasePayment>().HasData(leasePayments);
    }
}
