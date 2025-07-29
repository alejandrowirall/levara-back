using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Levara.Domain.Models;

namespace Levara.DAL.DbContext.EntityConfigurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(e => e.Amount)
                   .HasPrecision(18, 2);

            builder.Property(e => e.RunningBalance)
                   .HasPrecision(18, 2);

            builder.Property(e => e.BankAccountRunningBalance)
                   .HasPrecision(18, 2);

            builder.Property(e => e.LeaseRunningBalance)
                   .HasPrecision(18, 2);

            builder.HasOne(o => o.Property)
                   .WithMany()
                   .HasForeignKey(o => o.PropertyId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(o => o.Lease)
                   .WithMany()
                   .HasForeignKey(o => o.LeaseId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(o => o.OwnerBankAccount)
                  .WithMany()
                  .HasForeignKey(o => o.OwnerBankAccountId)
                  .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(o => o.PlaidTransaction)
                 .WithMany()
                 .HasForeignKey(o => o.PlaidTransactionId)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Payments")
                   .HasQueryFilter(c => !c.Deleted);
        }
    }
}
