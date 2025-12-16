using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Levara.Domain.Models;

namespace Levara.DAL.DbContext.EntityConfigurations
{
    public class RecurringChargeInstanceConfiguration : IEntityTypeConfiguration<RecurringChargeInstance>
    {
        public void Configure(EntityTypeBuilder<RecurringChargeInstance> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                   .ValueGeneratedOnAdd();

            builder.HasOne(o => o.RecurringCharge)
                   .WithMany()
                   .HasForeignKey(o => o.RecurringChargeId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(o => o.Transaction)
                   .WithMany()
                   .HasForeignKey(o => o.TransactionId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("RecurringChargeInstances")
                   .HasQueryFilter(c => !c.Deleted);
        }
    }
}
