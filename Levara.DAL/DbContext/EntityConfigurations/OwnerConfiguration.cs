using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Levara.Domain.Models;

namespace Levara.DAL.DbContext.EntityConfigurations
{
    public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
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

            builder.Property(o => o.ExternalId).HasMaxLength(100);
            builder.HasIndex(o => o.ExternalId)
                   .IsUnique()
                   .HasFilter("\"ExternalId\" IS NOT NULL");

            builder.ToTable("Owners")
                   .HasQueryFilter(c => !c.Deleted);
        }
    }
}
