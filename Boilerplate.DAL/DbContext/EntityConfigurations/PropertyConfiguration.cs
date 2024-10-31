using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Boilerplate.Domain.Models;

namespace Boilerplate.DAL.DbContext.EntityConfigurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                   .ValueGeneratedOnAdd();

            builder.HasOne(o => o.Address)
                   .WithMany()
                   .HasForeignKey(o => o.AddressId);

            builder.HasOne(o => o.Owner)
                   .WithMany()
                   .HasForeignKey(o => o.OwnerId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Properties")
                   .HasQueryFilter(c => !c.Deleted);
        }
    }
}
