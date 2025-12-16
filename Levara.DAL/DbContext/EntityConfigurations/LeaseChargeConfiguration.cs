using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Levara.Domain.Models;

namespace Levara.DAL.DbContext.EntityConfigurations
{
    public class LeaseChargeConfiguration : IEntityTypeConfiguration<LeaseCharge>
    {
        public void Configure(EntityTypeBuilder<LeaseCharge> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                   .ValueGeneratedOnAdd();

            builder.HasOne(o => o.Transaction)
                   .WithMany()
                   .HasForeignKey(o => o.TransactionId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(o => o.Type)
                   .WithMany()
                   .HasForeignKey(o => o.TypeId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("LeaseCharges")
                   .HasQueryFilter(c => !c.Deleted);
        }
    }
}
