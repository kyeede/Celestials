namespace Celestials.Core.Results;

using Celestials.Core.Errors;

public readonly record struct Result<T>
{
    public bool IsSuccess { get; }
    public T? Value { get; }
    public Error? Error { get; }

    public Result(bool isSuccess, T? value, Error? error)
    {
        if (isSuccess && error is not null)
        {
            throw new ArgumentException("A successful result cannot have an error.", nameof(error));
        }

        if (!isSuccess && error is null)
        {
            throw new ArgumentException("A failed result must have an error.", nameof(error));
        }

        if (isSuccess && value is null)
        {
            throw new ArgumentException("A successful result must have a value.", nameof(value));
        }

        IsSuccess = isSuccess;
        Value = value;
        Error = error;
    }

    internal static Result<T> Success(T value) => new(true, value, null);

    internal static Result<T> Failure(Error? error) => new(false, default, error);

    public override string ToString() => IsSuccess ? $"Success: {Value}" : $"Failure: {Error}";
}
