using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Levara.Domain.Models;

namespace Levara.DAL.DbContext.EntityConfigurations
{
    public class TransactionApplicationConfiguration : IEntityTypeConfiguration<TransactionApplication>
    {
        public void Configure(EntityTypeBuilder<TransactionApplication> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(e => e.AppliedAmount)
                   .HasPrecision(18, 2);

            builder.HasOne(o => o.ChargeTransaction)
                   .WithMany()
                   .HasForeignKey(o => o.ChargeTransactionId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(o => o.PaymentTransaction)
                   .WithMany()
                   .HasForeignKey(o => o.PaymentTransactionId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(o => o.Payment)
                  .WithMany()
                  .HasForeignKey(o => o.PaymentId)
                  .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("TransactionApplications")
                   .HasQueryFilter(c => !c.Deleted);
        }
    }
}
