

using Boilerplate.Shared.Domain.Bus.Commands;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Boilerplate.Application.Identity.Refresh;

public class RefreshCommand : Command<SignInHttpResult>
{
    public required string RefreshToken { get; init; }
}
