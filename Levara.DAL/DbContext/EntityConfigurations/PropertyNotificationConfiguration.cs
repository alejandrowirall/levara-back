using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Levara.Domain.Models;
using Levara.DAL.Extensions;

namespace Levara.DAL.DbContext.EntityConfigurations
{
    public class PropertyNotificationConfiguration : IEntityTypeConfiguration<PropertyNotification>
    {
        public void Configure(EntityTypeBuilder<PropertyNotification> builder)
        {
            builder.IgnoreAllPublicProperties();
        }
    }
}
