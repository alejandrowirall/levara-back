using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Levara.Domain.Models;

namespace Levara.DAL.DbContext.EntityConfigurations;

public class LeaseChargeTypeConfiguration : IEntityTypeConfiguration<LeaseChargeType>
{
    public void Configure(EntityTypeBuilder<LeaseChargeType> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id)
               .ValueGeneratedOnAdd();

        builder.ToTable("LeaseChargeTypes")
               .HasQueryFilter(c => !c.Deleted);
    }
}
