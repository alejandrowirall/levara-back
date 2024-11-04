

using Levara.Shared.Domain.Bus.Commands;
using System.ComponentModel.DataAnnotations;

namespace Levara.Application.Identity.Register;

public class RegisterCommand : Command<RegisterCommandResponse>
{
    /// <summary>
    /// The user's email address which acts as a user name.
    /// </summary>
    [EmailAddress]
    public required string Email { get; init; }

    /// <summary>
    /// The user's password.
    /// </summary>
    public required string Password { get; init; }
}
