namespace Celestials.Core.Results;

using Celestials.Core.Errors;

public readonly record struct Result
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    public Error Error
    {
        get
        {
            if (IsSuccess)
            {
                throw new InvalidOperationException(
                    "Cannot access Error when Result is a success."
                );
            }

            return field;
        }
    }

    internal Result(Error error)
    {
        if (error.Type is ErrorType.None)
        {
            throw new ArgumentException(
                "Error cannot be None for a failure result.",
                nameof(error)
            );
        }

        IsSuccess = false;
        Error = error;
    }

    private Result(bool isSuccess)
    {
        IsSuccess = isSuccess;
    }

    public static Result Success() => new(true);

    public static Result<T> Success<T>(T value) => new(value);

    public static Result Failure(Error error) => new(error);

    public static Result<T> Failure<T>(Error error) => new(error);

    public static implicit operator bool(Result result) => result.IsFailure;

    public static implicit operator Result(Error error) => Failure(error);

    public override string ToString() => IsSuccess ? "Success" : $"Failure: {Error}";
}
