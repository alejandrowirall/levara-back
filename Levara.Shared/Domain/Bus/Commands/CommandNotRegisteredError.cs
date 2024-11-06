
namespace Levara.Shared.Domain.Bus.Commands;

public class CommandNotRegisteredError<TResponse> : Exception
{
    public CommandNotRegisteredError(Command<TResponse> command) : base(
        $"The command {command} has not a command handler associated")
    {
    }
}
