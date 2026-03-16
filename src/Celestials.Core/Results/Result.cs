namespace Celestials.Core.Results;

using Celestials.Core.Errors;

public readonly record struct Result : IEquatable<Result>
{
    private readonly Error _error;

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

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

    private Result(bool isSuccess, Error error)
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
        _error = error;
    }

    public static Result Success() => new(true, Error.None);

    public static Result Failure(Error error) => new(false, error);

    public static Result<T> Success<T>(T value) => Result<T>.Success(value);

    public static Result<T> Failure<T>(Error error) => Result<T>.Failure(error);

    public static implicit operator bool(Result result) => result.IsSuccess;

    public override string ToString() => IsSuccess ? "Success" : $"Failure({_error})";
}
