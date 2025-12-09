using Levara.Domain.Enum;
using Levara.Domain.Models;
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

        List<Maintenance> maintenances = new();
        List<MaintenanceCharge> maintenanceCharges = new();

        List<ExpenseCharge> expenseCharges = new();

        Transaction? lastTransaction = default;
        Transaction? lastLeaseTransaction = default;

        for (int i = 1; i < 13; i++)
        {
            lastTransaction = transactions.OrderByDescending(t => t.Id).FirstOrDefault();
            lastLeaseTransaction = transactions.Where(t => t.LeaseId == 1).OrderByDescending(t => t.Id).FirstOrDefault();

            Transaction leaseChargeTransaction = new()
            {
                Id = transactions.Count() + 1,
                Type = TransactionType.Lease,
                SubType = TransactionSubType.Charge,
                LeaseId = 1,
                Date = new DateTime(2024, i, 2, 0, 0, 0, DateTimeKind.Utc),
                Description = $"Charge of rent {new DateTime(2024, i, 1, 0, 0, 0, DateTimeKind.Utc).ToShortDateString()}",
                Amount = 1500,
                RunningBalance = i == 1 ? -1500 : lastTransaction!.RunningBalance - 1500,
                LeaseRunningBalance = i == 1 ? -1500 : lastLeaseTransaction!.LeaseRunningBalance - 1500,
                PropertyId = 1,
                Status = TransactionStatus.Unpaid,
                DueDate = new DateTime(2024, i, 10, 0, 0, 0, DateTimeKind.Utc),
                CreatorId = 1,
                CreatedDate = datatimeApp,
                LastEditorId = 1,
                LastEditedDate = datatimeApp,
            };

            transactions.Add(leaseChargeTransaction);

            LeaseCharge leaseCharge = new()
            {
                Id = leaseCharges.Count() + 1,
                LeaseId = 1,
                TransactionId = leaseChargeTransaction.Id,
                Description = leaseChargeTransaction.Description,
                CreatorId = 1,
                CreatedDate = datatimeApp,
                LastEditorId = 1,
                LastEditedDate = datatimeApp,
            };

            leaseCharges.Add(leaseCharge);

            lastTransaction = transactions.OrderByDescending(t => t.Id).FirstOrDefault();

            Transaction maintenanceChargeTransaction = new()
            {
                Id = transactions.Count() + 1,
                Type = TransactionType.Maintenance,
                SubType = TransactionSubType.Charge,
                Date = new DateTime(2024, i, 2, 0, 0, 0, DateTimeKind.Utc),
                Description = $"Maintenance of {new DateTime(2024, i, 2, 0, 0, 0, DateTimeKind.Utc).ToShortDateString()}",
                Amount = 800,
                RunningBalance = lastTransaction!.RunningBalance - 800,
                LeaseRunningBalance = null, // No aplica para maintenance
                PropertyId = 1,
                Status = TransactionStatus.Unpaid,
                DueDate = new DateTime(2024, i, 15, 0, 0, 0, DateTimeKind.Utc),
                CreatorId = 1,
                CreatedDate = datatimeApp,
                LastEditorId = 1,
                LastEditedDate = datatimeApp,
            };

            transactions.Add(maintenanceChargeTransaction);

            Maintenance maintenance = new()
            {
                Id = maintenances.Count() + 1,
                Title = $"Plumber Service",
                Description = "Plumber Service in Property 1",
                TypeId = 1,
                PropertyId = 1,
                CreatorId = 1,
                DueDate = new DateTime(2024, i, 10, 0, 0, 0, DateTimeKind.Utc),
                Status = MaintenanceStatus.Completed,
                CreatedDate = datatimeApp,
                LastEditorId = 1,
                LastEditedDate = datatimeApp,
            };

            maintenances.Add(maintenance);

            MaintenanceCharge maintenanceCharge = new()
            {
                Id = maintenanceCharges.Count() + 1,
                MaintenanceId = maintenance.Id,
                TransactionId = maintenanceChargeTransaction.Id,
                CreatorId = 1,
                CreatedDate = datatimeApp,
                LastEditorId = 1,
                LastEditedDate = datatimeApp,
            };

            maintenanceCharges.Add(maintenanceCharge);

            lastTransaction = transactions.OrderByDescending(t => t.Id).FirstOrDefault();

            Transaction expenseChargeTransaction = new()
            {
                Id = transactions.Count() + 1,
                Type = TransactionType.Expense,
                SubType = TransactionSubType.Charge,
                Date = new DateTime(2024, i, 1, 0, 0, 0, DateTimeKind.Utc),
                Description = $"Charge of cleaning {new DateTime(2024, i, 3, 0, 0, 0, DateTimeKind.Utc).ToShortDateString()}",
                Amount = 150,
                RunningBalance = lastTransaction!.RunningBalance - 150,
                LeaseRunningBalance = null, // No aplica para expense
                PropertyId = 1,
                Status = TransactionStatus.Unpaid,
                DueDate = new DateTime(2024, i, 20, 0, 0, 0, DateTimeKind.Utc),
                CreatorId = 1,
                CreatedDate = datatimeApp,
                LastEditorId = 1,
                LastEditedDate = datatimeApp,
            };

            transactions.Add(expenseChargeTransaction);

            ExpenseCharge expenseCharge = new()
            {
                Id = maintenanceCharges.Count() + 1,
                ExpenseId = 1,
                TransactionId = expenseChargeTransaction.Id,
                CreatorId = 1,
                CreatedDate = datatimeApp,
                LastEditorId = 1,
                LastEditedDate = datatimeApp,
            };

            expenseCharges.Add(expenseCharge);

            //if (i < 12)
            //{
            //    Transaction paymentTransaction = new()
            //    {
            //        Id = transactions.Count() + 1,
            //        Type = TransactionType.Lease,
            //        SubType = TransactionSubType.Payment,
            //        LeaseId = 1,
            //        Date = new DateTime(2024, i, 5, 0, 0, 0, DateTimeKind.Utc),
            //        Description = $"Payment of rent {new DateTime(2024, i, 5, 0, 0, 0, DateTimeKind.Utc).ToShortDateString()}",
            //        Amount = 1500,
            //        RunningBalance = leaseChargeTransaction!.RunningBalance + 1500,
            //        LeaseRunningBalance = leaseChargeTransaction!.LeaseRunningBalance + 1500,
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
        //    Date = new DateTime(2024, 12, 9, 0, 0, 0, DateTimeKind.Utc),
        //    Description = $"Charge of maintenance {new DateTime(2024, 12, 9, 0, 0, 0, DateTimeKind.Utc).ToShortDateString()}",
        //    Amount = 450,
        //    RunningBalance = lastTransaction!.RunningBalance - 450,
        //    LeaseRunningBalance = 0, // No aplica para maintenance
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

        this.modelBuilder.Entity<Maintenance>().HasData(maintenances);
        this.modelBuilder.Entity<MaintenanceCharge>().HasData(maintenanceCharges);

        this.modelBuilder.Entity<ExpenseCharge>().HasData(expenseCharges);
        
    }
}
