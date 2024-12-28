using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Levara.Domain.Models;

namespace Levara.DAL.DbContext.EntityConfigurations;

public class DomainEventPrimitiveConfiguration : IEntityTypeConfiguration<DomainEventPrimitive>
{
    public void Configure(EntityTypeBuilder<DomainEventPrimitive> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id)
               .ValueGeneratedOnAdd();

        builder.Property(o => o.EventId);
        builder.Property(o => o.Name);

        builder.Property(n => n.Body)
                .HasColumnType("jsonb");

        builder.ToTable("DomainEvents")
               .HasQueryFilter(c => !c.Deleted);
    }
}
