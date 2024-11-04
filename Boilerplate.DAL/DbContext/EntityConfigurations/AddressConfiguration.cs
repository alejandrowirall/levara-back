using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Levara.Domain.Models;

namespace Levara.DAL.DbContext.EntityConfigurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(o => o.Street);
            builder.Property(o => o.AdditionalLine);
            builder.Property(o => o.City);
            builder.Property(o => o.Street);
            builder.Property(o => o.PostalCode);

            builder.ToTable("Addresses")
                   .HasQueryFilter(c => !c.Deleted);
        }
    }
}
