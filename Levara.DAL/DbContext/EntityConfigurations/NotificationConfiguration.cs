using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Levara.Domain.Models;
using Levara.Domain.Enum;

namespace Levara.DAL.DbContext.EntityConfigurations;

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id)
               .ValueGeneratedOnAdd();

        builder.HasOne(o => o.Receiver)
               .WithMany()
               .HasForeignKey(o => o.ReceiverId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.ToTable("Notifications")
               .HasQueryFilter(c => !c.Deleted);

        builder.Property(n => n.Data)
               .HasColumnType("jsonb");

        var biscriminatorBuilder = builder.HasDiscriminator(n => n.Type);

        var targetAssembly = typeof(Notification).Assembly;
        var targetNamespace = typeof(Notification).Namespace;
        var notificationType = typeof(NotificationType);

        foreach (var type in targetAssembly.GetTypes()
                                           .Where(t => t.IsSubclassOf(typeof(Notification)) &&
                                                       !t.IsAbstract &&
                                                       t.Namespace == targetNamespace))
        {
            // Assume that the type name matches a value in NotificationType
            var enumValue = Enum.Parse(notificationType, type.Name.Replace("Notification", ""));
            biscriminatorBuilder = biscriminatorBuilder.HasValue(type, (NotificationType)enumValue);
        }
    }
}
