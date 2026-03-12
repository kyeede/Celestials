namespace Celestials.Core.Results;

using Celestials.Core.Errors;

public readonly record struct Result
{
    public bool IsSuccess { get; }
    public Error? Error { get; }

    public Result(bool isSuccess, Error? error)
    {
        if (isSuccess && error is not null)
        {
            throw new ArgumentException("A successful result cannot have an error.", nameof(error));
        }

        if (!isSuccess && error is null)
        {
            throw new ArgumentException("A failed result must have an error.", nameof(error));
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() => new(true, null);

    public static Result<T> Success<T>(T value) => new(true, value, null);

    public static Result Failure(Error? error) => new(false, error);

    public override string ToString() => IsSuccess ? "Success" : $"Failure: {Error}";
}
