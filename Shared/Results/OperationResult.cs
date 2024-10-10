
namespace Boilerplate.Shared.Results;

public class OperationResult<T>
{
    public bool Success { get; private set; }
    public T? Result { get; private set; }
    public ErrorDetails? Error { get; private set; }

    private OperationResult(bool success, T? result, ErrorDetails? error)
    {
        Success = success;
        Result = result;
        Error = error;
    }

    public static OperationResult<T> SuccessResult(T result)
    {
        return new OperationResult<T>(true, result, null);
    }

    public static OperationResult<T> ErrorResult(ErrorDetails error)
    {
        return new OperationResult<T>(false, default, error);
    }
}
