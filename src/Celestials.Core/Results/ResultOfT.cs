using Celestials.Core.Errors;

namespace Celestials.Core.Results;

public readonly record struct Result<T>
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    public Error Error { get; }

    public T Value
    {
        get
        {
            if (IsFailure)
            {
                throw new InvalidOperationException("Cannot access the value of a failed result.");
            }

            return field ?? throw new InvalidOperationException("Value is not set.");
        }
    }

    private Result(T value)
    {
        ArgumentNullException.ThrowIfNull(value);

        Value = value;
        IsSuccess = true;
        Error = Error.None;
    }

    private Result(Error error)
    {
        if (error.IsNone)
        {
            throw new ArgumentException("A failed result must contain an error.", nameof(error));
        }

        Value = default;
        IsSuccess = false;
        Error = error;
    }

    public static Result<T> Success(T value)
    {
        return new(value);
    }

    public static Result<T> Failure(Error error)
    {
        return new(error);
    }

    public static implicit operator Result<T>(T value)
    {
        return Success(value);
    }

    public static implicit operator Result<T>(Error error)
    {
        return Failure(error);
    }
}
