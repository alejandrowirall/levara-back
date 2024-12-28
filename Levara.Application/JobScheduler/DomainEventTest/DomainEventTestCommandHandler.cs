using Levara.Domain.DAL.Repositories;
using Levara.Domain.ExternalServices;
using Levara.ExternalService.Emails;
using Levara.Shared.Domain.Bus.Commands;
using Levara.Shared.Results;

namespace Levara.Application.JobScheduler.DomainEventTest;

public class DomainEventTestCommandHandler : ICommandHandler<DomainEventTestCommand, DomainEventTestCommandResponse>
{
    private readonly IEmailService _emailService;
    private readonly IOwnerRepository _ownerRepository;
    public DomainEventTestCommandHandler(IEmailService emailService,
        IOwnerRepository ownerRepository) 
    {
        _emailService = emailService;
        _ownerRepository = ownerRepository;
    }
    public async Task<OperationResult<DomainEventTestCommandResponse>> Handle(DomainEventTestCommand command)
    {
        var query = _ownerRepository.GetAll().Select(a => a.Email);

        var ownerEmails = await _ownerRepository.ToListAsync(query);

        var content = @$"
        <!DOCTYPE html>
        <html lang=""en"">
        <head>
            <meta charset=""UTF-8"">
            <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
            <title>Test Event Bridge</title>
        </head>
        <body>
            <div class=""container"">
            <div class=""header"">
                <h1>Test Event Bridge</h1>
            </div>
            <div class=""content"">
                <h1>Hello, {{UserName}}!</h1>
                <p>This is the list of owners registered in the system:</p>
                <p>{string.Join(", ", ownerEmails)}</p>
            </div>
            <div class=""footer"">
                <p>This is an automatically generated email. Please do not reply to this message.</p>
            </div>
        </div>
        </body>
        </html>
        ";

        var recipients = new List<string> { "soliaguille@gmail.com" };

        await _emailService.SendEmailAsync(recipients, "Test Event Bridge from LevaraFunction", content);

        return OperationResult<DomainEventTestCommandResponse>.SuccessResult(new());

    }
}
