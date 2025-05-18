using Levara.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Levara.DAL.DbContext.EntityConfigurations;

public class PlaidReconciliationConfiguration : IEntityTypeConfiguration<PlaidReconciliation>
{
    public void Configure(EntityTypeBuilder<PlaidReconciliation> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id)
               .ValueGeneratedOnAdd();

        builder.HasOne(o => o.Transaction)
               .WithMany()
               .HasForeignKey(o => o.TransactionId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(o => o.PlaidTransaction)
               .WithMany()
               .HasForeignKey(o => o.PlaidTransactionId)
               .OnDelete(DeleteBehavior.NoAction);
        
        builder.ToTable("PlaidReconciliation")
               .HasQueryFilter(c => !c.Deleted);
    }
}
