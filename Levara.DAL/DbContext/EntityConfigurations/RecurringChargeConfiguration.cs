using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Levara.Domain.Models;

namespace Levara.DAL.DbContext.EntityConfigurations
{
    public class RecurringChargeConfiguration : IEntityTypeConfiguration<RecurringCharge>
    {
        public void Configure(EntityTypeBuilder<RecurringCharge> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                   .ValueGeneratedOnAdd();

            builder.HasOne(o => o.Expense)
                   .WithMany()
                   .HasForeignKey(o => o.ExpenseId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(o => o.MaintenanceType)
                   .WithMany()
                   .HasForeignKey(o => o.MaintenanceTypeId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(o => o.Lease)
                   .WithMany()
                   .HasForeignKey(o => o.LeaseId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(o => o.LeaseChargeType)
                   .WithMany()
                   .HasForeignKey(o => o.LeaseChargeTypeId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(o => o.Property)
                   .WithMany()
                   .HasForeignKey(o => o.PropertyId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Property(n => n.MatchTags)
                   .HasColumnType("text[]");

            builder.ToTable("RecurringCharges")
                   .HasQueryFilter(c => !c.Deleted);
        }
    }
}
