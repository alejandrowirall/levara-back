using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Levara.Domain.Models;

namespace Levara.DAL.DbContext.EntityConfigurations;

public class MaintenanceConfiguration : IEntityTypeConfiguration<Maintenance>
{
    public void Configure(EntityTypeBuilder<Maintenance> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id)
               .ValueGeneratedOnAdd();

        builder.HasOne(o => o.Type)
              .WithMany()
              .HasForeignKey(o => o.TypeId)
              .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(o => o.Property)
              .WithMany()
              .HasForeignKey(o => o.PropertyId)
              .OnDelete(DeleteBehavior.NoAction);

        builder.ToTable("Maintenances")
               .HasQueryFilter(c => !c.Deleted);
    }
}
