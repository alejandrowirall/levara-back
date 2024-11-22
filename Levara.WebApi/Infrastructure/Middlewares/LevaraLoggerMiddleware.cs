using Levara.Domain.Contexts;
using Levara.Shared.Results;
using Levara.WebApi.Infrastructure.Security;
using Newtonsoft.Json;
using Serilog.Context;

namespace Levara.WebApi.Infrastructure.Middlewares;

public class LevaraLoggerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LevaraLoggerMiddleware> _logger;

    public LevaraLoggerMiddleware(RequestDelegate next,
        ILogger<LevaraLoggerMiddleware> logger)
    {
        _logger = logger;

        if (next == null) throw new ArgumentNullException(nameof(next));
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            var correlationId = httpContext.Request.Headers["X-Correlation-ID"].FirstOrDefault() ?? Guid.NewGuid().ToString();
            var idempotencyId = httpContext.Request.Headers["X-Idempotency-ID"].FirstOrDefault() ?? Guid.NewGuid().ToString();
            var requestId = httpContext.Request.Headers["X-Request-ID"].FirstOrDefault() ?? Guid.NewGuid().ToString();

            var contextIdentifier = httpContext.RequestServices.GetService<ContextIdentifier>();
            contextIdentifier!.CorrelationId = correlationId;
            contextIdentifier!.IdempotencyId = idempotencyId;
            contextIdentifier!.RequestId = requestId;

            string? path = httpContext.Request?.Path.Value;

            var userContext = httpContext.RequestServices.GetService<IUserContext>();

            //using (LogContext.PushProperty(nameof(ContextIdentifier.CorrelationId), new Guid(contextIdentifier!.CorrelationId)))
            //using (LogContext.PushProperty(nameof(ContextIdentifier.RequestId), new Guid(contextIdentifier!.RequestId)))
            //using (LogContext.PushProperty("UserId", userContext!.Id))
            //using (LogContext.PushProperty(nameof(IUserContext.Username), userContext!.Username))
            //using (LogContext.PushProperty("Path", path))
            //{

                await this._next.Invoke(httpContext);

            //}

        }
        catch (Exception ex)
        {

            _logger.LogError(ex, "Error in LevaraLoggerMiddleware");

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = 500;


            string errorResponse = JsonConvert.SerializeObject(OperationResult<bool>.ErrorResult(new ErrorDetails(500, "Internal Server Error")));

            await httpContext.Response.WriteAsync(errorResponse);

        }
    }
}
