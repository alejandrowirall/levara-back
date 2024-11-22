using Levara.Shared.Results;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Levara.WebApi.Infrastructure.Middlewares;

public class LevaraExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LevaraExceptionMiddleware> _logger;

    public LevaraExceptionMiddleware(RequestDelegate next,
        ILogger<LevaraExceptionMiddleware> logger)
    {
        _logger = logger;

        if (next == null) throw new ArgumentNullException(nameof(next));
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {

            await this._next.Invoke(httpContext);
            
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = 500;


            string errorResponse = JsonConvert.SerializeObject(OperationResult<bool>.ErrorResult(new ErrorDetails(500, "Internal Server Error")));

            await httpContext.Response.WriteAsync(errorResponse);

        }
        finally
        {
            
        }
    }
}
