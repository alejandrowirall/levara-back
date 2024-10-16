using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Boilerplate.Domain.Models;

namespace Boilerplate.DAL.DbContext.EntityConfigurations
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

            builder.HasOne<ApplicationUser>()
                   .WithMany()
                   .HasForeignKey(o => o.ApplicationUserId)
                   .IsRequired();

            builder.HasOne(o => o.Address)
                   .WithMany()
                   .HasForeignKey(o => o.AddressId);

            builder.ToTable("Owners")
                   .HasQueryFilter(c => !c.Deleted);
        }
    }
}
