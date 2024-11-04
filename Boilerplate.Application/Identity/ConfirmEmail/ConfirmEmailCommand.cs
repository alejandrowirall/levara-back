

using Levara.Shared.Domain.Bus.Commands;

namespace Levara.Application.Identity.ConfirmEmail;

public class ConfirmEmailCommand : Command<ConfirmEmailCommandResponse>
{
    public required string UserId { get; init; }

    public required string Code { get; init; }
}
