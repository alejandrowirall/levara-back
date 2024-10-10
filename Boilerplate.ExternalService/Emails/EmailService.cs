
using FluentEmail.Core;
using FluentEmail.Core.Models;
using System.Diagnostics;
using Boilerplate.ExternalService.Emails.Configurations;
using Microsoft.Extensions.Configuration;
using Boilerplate.Domain.ExternalServices;

namespace Boilerplate.ExternalService.Emails;

public class EmailService : IEmailService
{
    private readonly IFluentEmailFactory _mail;
    private readonly SmtpConfiguration _smtpConfiguration;

    public EmailService(IFluentEmailFactory mail,
        IConfiguration configuration)
    {
        _mail = mail;
        _smtpConfiguration = new SmtpConfiguration().Bind(configuration);
    }

    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        try
        {
            await _mail
                    .Create()
                    .To(email)
                    .SetFrom(_smtpConfiguration.Address)
                    .Subject(subject)
                    .Body(htmlMessage, true)
                    .SendAsync();
        }
        catch(Exception ex)
        {
            Debugger.Break();
        }
    }

    public async Task SendEmailAsync(IEnumerable<string> emails, string subject, string htmlMessage)
    {
        await _mail
                 .Create()
                 .To(GetAddresses(emails))
                 .SetFrom(_smtpConfiguration.Address)
                 .Subject(subject)
                 .Body(htmlMessage)
                 .SendAsync();
    }

    private List<Address> GetAddresses(IEnumerable<string> emails)
    {
        return emails.Select(email => new Address(email)).ToList();
    }
}
