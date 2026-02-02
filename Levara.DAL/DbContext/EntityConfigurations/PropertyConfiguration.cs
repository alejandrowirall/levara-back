using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Levara.Domain.Models;

namespace Levara.DAL.DbContext.EntityConfigurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(e => e.Price)
                   .HasPrecision(18, 2);

            builder.HasOne(o => o.Address)
                   .WithMany()
                   .HasForeignKey(o => o.AddressId);

            builder.HasOne(o => o.Owner)
                   .WithMany()
                   .HasForeignKey(o => o.OwnerId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(o => o.OwnerBankAccount)
                   .WithMany(o => o.Properties)
                   .HasForeignKey(o => o.OwnerBankAccountId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.ToTable("Properties")
                   .HasQueryFilter(c => !c.Deleted);
        }
    }
}
