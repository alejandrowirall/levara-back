using Levara.Domain.ExternalServices;
using Levara.ExternalService.Emails.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Levara.ExternalService.Emails.Extensions;

public static class EmailServiceExtensions
{
    public static IServiceCollection AddEmailService(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IEmailService, EmailService>();

        var smtpConfig = new SmtpConfiguration().Bind(configuration);

        services.AddFluentEmail(smtpConfig.Address)
            .AddSmtpSender(() =>
            {
                var smtpConfig = new SmtpConfiguration().Bind(configuration);
                return smtpConfig.GenerateSmtpClient();
            });

        return services;
    }
}
