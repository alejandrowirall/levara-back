using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Levara.Domain.Models;

namespace Levara.DAL.DbContext.EntityConfigurations
{
    public class LeaseConfiguration : IEntityTypeConfiguration<Lease>
    {
        public void Configure(EntityTypeBuilder<Lease> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(e => e.Amount)
                   .HasPrecision(18, 2);

            builder.HasOne(o => o.Owner)
                   .WithMany()
                   .HasForeignKey(o => o.OwnerId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(o => o.Property)
                  .WithMany()
                  .HasForeignKey(o => o.PropertyId)
                  .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(o => o.Tenant)
                  .WithMany()
                  .HasForeignKey(o => o.TenantId)
                  .OnDelete(DeleteBehavior.NoAction);

            builder.Property(o => o.ExternalId).HasMaxLength(100);
            builder.HasIndex(o => o.ExternalId)
                   .IsUnique()
                   .HasFilter("\"ExternalId\" IS NOT NULL");

            builder.ToTable("Leases")
                   .HasQueryFilter(c => !c.Deleted);
        }
    }
}
