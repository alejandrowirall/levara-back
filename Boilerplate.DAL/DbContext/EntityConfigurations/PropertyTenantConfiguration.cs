using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Levara.Domain.Models;

namespace Levara.DAL.DbContext.EntityConfigurations
{
    public class PropertyTenantConfiguration : IEntityTypeConfiguration<PropertyTenant>
    {
        public void Configure(EntityTypeBuilder<PropertyTenant> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                   .ValueGeneratedOnAdd();

            builder.HasOne(o => o.Property)
                   .WithMany()
                   .HasForeignKey(o => o.PropertyId);

            builder.HasOne(o => o.Tenant)
                   .WithMany()
                   .HasForeignKey(o => o.TenantId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("PropertyTenants")
                   .HasQueryFilter(c => !c.Deleted);
        }
    }
}
