using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Levara.Domain.Models;

namespace Levara.DAL.DbContext.EntityConfigurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(e => e.Amount)
                   .HasPrecision(18, 2);

            builder.HasOne(o => o.Property)
                   .WithMany()
                   .HasForeignKey(o => o.PropertyId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Transactions")
                   .HasQueryFilter(c => !c.Deleted);
        }
    }
}
