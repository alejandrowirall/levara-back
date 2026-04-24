using Levara.Application.External.SyncEntities;
using Levara.Shared.Domain.Bus.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Levara.WebApi.Controllers;

[Route("api/external")]
[ApiController]
public class ExternalController : ControllerBase
{
    private readonly ICommandBus _commandBus;

    public ExternalController(ICommandBus commandBus)
        => _commandBus = commandBus;

    /// <summary>
    /// Sincroniza Owner + Tenant + Property desde un sistema externo.
    /// Usa ExternalId de cada sección para crear o reutilizar entidades existentes.
    /// Autenticación: header X-API-KEY.
    /// </summary>
    [HttpPost("sync-entities")]
    public async Task<IActionResult> SyncEntities([FromBody] SyncEntitiesCommand command)
    {
        var response = await _commandBus.Dispatch(command);
        return new ObjectResult(response) { StatusCode = response.Error?.StatusCode };
    }
}
