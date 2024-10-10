
namespace Boilerplate.Shared.Results;

public class ErrorDetails
{
    public int StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;
    public string? Detail { get; set; }

    public ErrorDetails(int statusCode, string message, string? detail = null)
    {
        StatusCode = statusCode;
        Message = message;
        Detail = detail;
    }
}
