namespace Celestials.Core.Results;

using Celestials.Core.Errors;

public readonly record struct Result
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }

    private Result(bool isSuccess, Error error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success()
    {
        return new(true, Error.None);
    }

    public static Result Failure(Error error)
    {
        return new(false, error);
    }

    public static Result<T> Success<T>(T value)
    {
        return Result<T>.Success(value);
    }

    public static Result<T> Failure<T>(Error error)
    {
        return Result<T>.Failure(error);
    }

    public static implicit operator Result(Error error)
    {
        return Failure(error);
    }

    public override string ToString()
    {
        return IsSuccess ? "Success" : $"Failure({Error})";
    }
}
