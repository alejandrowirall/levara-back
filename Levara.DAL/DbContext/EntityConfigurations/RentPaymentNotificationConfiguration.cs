using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Levara.Domain.Models;
using Levara.DAL.Extensions;

namespace Levara.DAL.DbContext.EntityConfigurations;

public class RentPaymentNotificationConfiguration : IEntityTypeConfiguration<RentPaymentNotification>
{
    public void Configure(EntityTypeBuilder<RentPaymentNotification> builder)
    {
        builder.IgnoreAllPublicProperties();
    }
}
