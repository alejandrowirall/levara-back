
using System.ComponentModel.DataAnnotations;

namespace Levara.Shared.Results;

public class ErrorDetails
{
    public int StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;
    public IEnumerable<ValidationResult>? ValidationResults { get; set; }

    public ErrorDetails(int statusCode, string message, List<ValidationResult>? validationResults = null)
    {
        StatusCode = statusCode;
        Message = message;
        ValidationResults = validationResults?.Where(vr => !string.IsNullOrEmpty(vr.ErrorMessage));
    }
}
