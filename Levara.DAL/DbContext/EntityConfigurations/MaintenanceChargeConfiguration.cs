using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Levara.Domain.Models;

namespace Levara.DAL.DbContext.EntityConfigurations;

public class MaintenanceChargeConfiguration : IEntityTypeConfiguration<MaintenanceCharge>
{
    public void Configure(EntityTypeBuilder<MaintenanceCharge> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id)
               .ValueGeneratedOnAdd();

        builder.HasOne(o => o.Transaction)
               .WithMany()
               .HasForeignKey(o => o.TransactionId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(o => o.Maintenance)
               .WithMany()
               .HasForeignKey(o => o.MaintenanceId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.ToTable("MaintenanceCharges")
               .HasQueryFilter(c => !c.Deleted);
    }
}
