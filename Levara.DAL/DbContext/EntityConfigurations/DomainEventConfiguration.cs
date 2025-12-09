using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Levara.Domain.Models;

namespace Levara.DAL.DbContext.EntityConfigurations;

public class DomainEventConfiguration : IEntityTypeConfiguration<DomainEvent>
{
    public void Configure(EntityTypeBuilder<DomainEvent> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id)
               .ValueGeneratedOnAdd();

        builder.Property(o => o.EventId)
               .IsRequired();

        builder.HasIndex(o => o.EventId)
               .IsUnique();

        builder.Property(o => o.Name);
        builder.Property(o => o.Status);
        builder.Property(o => o.EntityId);

        builder.Property(n => n.Data)
                .HasColumnType("jsonb");

        builder.ToTable("DomainEvents")
               .HasQueryFilter(c => !c.Deleted);

    }
}
