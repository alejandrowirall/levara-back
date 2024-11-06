using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Boilerplate.Domain.Models;

namespace Boilerplate.DAL.DbContext.EntityConfigurations
{
    public class LeaseConfiguration : IEntityTypeConfiguration<Lease>
    {
        public void Configure(EntityTypeBuilder<Lease> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                   .ValueGeneratedOnAdd();

            

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

            builder.ToTable("Leases")
                   .HasQueryFilter(c => !c.Deleted);
        }
    }
}
