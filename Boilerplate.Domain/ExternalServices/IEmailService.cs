
namespace Boilerplate.Domain.ExternalServices;

public interface IEmailService
{
    Task SendEmailAsync(string email, string subject, string htmlMessage);

    Task SendEmailAsync(IEnumerable<string> emails, string subject, string htmlMessage);
}
