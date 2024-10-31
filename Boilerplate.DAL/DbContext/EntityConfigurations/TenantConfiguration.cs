using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Boilerplate.Domain.Models;

namespace Boilerplate.DAL.DbContext.EntityConfigurations
{
    public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(o => o.Name);
            builder.Property(o => o.Surname);
            builder.Property(o => o.CompanyName);

            builder.Property(o => o.Identification);
            builder.Property(o => o.IdentificationType);

            builder.Property(o => o.PersonType);

            builder.HasOne(o => o.ApplicationUser)
                   .WithMany()
                   .HasForeignKey(o => o.ApplicationUserId);

            builder.HasOne(o => o.Address)
                   .WithMany()
                   .HasForeignKey(o => o.AddressId);

            builder.ToTable("Tenants")
                   .HasQueryFilter(c => !c.Deleted);
        }
    }
}
