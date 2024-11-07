using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Levara.Domain.Models;

namespace Levara.DAL.DbContext.EntityConfigurations
{
    public class OwnerBankAccountConfiguration : IEntityTypeConfiguration<OwnerBankAccount>
    {
        public void Configure(EntityTypeBuilder<OwnerBankAccount> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                   .ValueGeneratedOnAdd();

           

            builder.HasOne(o => o.Owner)
                   .WithMany()
                   .HasForeignKey(o => o.OwnerId);

            builder.Property(o => o.CreatedDate)
                   .HasColumnType("timestamp without time zone");

            builder.Property(o => o.LastEditedDate)
                    .HasColumnType("timestamp without time zone");

            builder.ToTable("OwnerBankAccounts")
                   .HasQueryFilter(c => !c.Deleted);
        }
    }
}
