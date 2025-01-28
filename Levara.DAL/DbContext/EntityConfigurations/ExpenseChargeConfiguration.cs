using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Levara.Domain.Models;

namespace Levara.DAL.DbContext.EntityConfigurations;

public class ExpenseChargeConfiguration : IEntityTypeConfiguration<ExpenseCharge>
{
    public void Configure(EntityTypeBuilder<ExpenseCharge> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id)
               .ValueGeneratedOnAdd();

        builder.HasOne(o => o.Transaction)
               .WithMany()
               .HasForeignKey(o => o.TransactionId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(o => o.Expense)
               .WithMany()
               .HasForeignKey(o => o.ExpenseId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.ToTable("ExpenseCharges")
               .HasQueryFilter(c => !c.Deleted);
    }
}
