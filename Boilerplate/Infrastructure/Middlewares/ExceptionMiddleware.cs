using Boilerplate.Shared.Results;
using Newtonsoft.Json;

namespace Boilerplate.WebApi.Infrastructure.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> logger;

        public ExceptionMiddleware(RequestDelegate next,
                                   ILogger<ExceptionMiddleware> logger)
        {
            this.logger = logger;

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
}
