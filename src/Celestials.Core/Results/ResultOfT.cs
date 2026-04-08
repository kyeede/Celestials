namespace Celestials.Core.Results;

using Celestials.Core.Errors;

public readonly record struct Result<T>
{
    private readonly T? _value;
    private readonly Error _error;

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    public T Value
    {
        get
        {
            if (IsFailure)
            {
                throw new InvalidOperationException("Failed result does not contain a value.");
            }

            return _value
                ?? throw new InvalidOperationException("Successful result must contain a value.");
        }
    }

    public Error Error
    {
        get
        {
            if (IsSuccess)
            {
                throw new InvalidOperationException("Successful result does not contain an error.");
            }

            return _error;
        }
    }

    private Result(bool isSuccess, T? value, Error error)
    {
        if (isSuccess && !error.IsNone)
        {
            throw new ArgumentException(
                "Successful result cannot contain an error.",
                nameof(error)
            );
        }

        if (!isSuccess && error.IsNone)
        {
            throw new ArgumentException("Failed result must contain an error.", nameof(error));
        }

        IsSuccess = isSuccess;
        _value = value;
        _error = error;
    }

    internal static Result<T> Success(T value) => new(true, value, Error.None);

    internal static Result<T> Failure(Error error) => new(false, default, error);

    public static implicit operator Result<T>(T value) => Success(value);

    public override string ToString() => IsSuccess ? $"Success({_value})" : $"Failure({_error})";
}
