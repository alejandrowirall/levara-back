using Levara.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levara.DAL.DbContext.EntityConfigurations
{
    public class PlaidTransactionConfiguration : IEntityTypeConfiguration<PlaidTransaction>
    {
        public void Configure(EntityTypeBuilder<PlaidTransaction> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(e => e.Amount)
                   .HasPrecision(18, 2);
            builder.HasOne(o => o.OwnerBankAccount)
                   .WithMany()
                   .HasForeignKey(o => o.OwnerBankAccountId)
                   .OnDelete(DeleteBehavior.NoAction);
            
            builder.ToTable("PlaidTransaction")
                   .HasQueryFilter(c => !c.Deleted);
        }
    }
}
