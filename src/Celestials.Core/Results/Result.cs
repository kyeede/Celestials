using Celestials.Core.Errors;

namespace Celestials.Core.Results;

public readonly record struct Result
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    public Error Error { get; }

    private Result(bool isSuccess, Error error)
    {
        if (isSuccess)
        {
            if (!error.IsNone)
            {
                throw new ArgumentException("A successful result cannot contain an error.", nameof(error));
            }
        }
        else if (error.IsNone)
        {
            throw new ArgumentException("A failed result must contain an error.", nameof(error));
        }

        IsSuccess = isSuccess;
        Error = isSuccess ? Error.None : error;
    }

    public static Result Success()
    {
        return new(true, Error.None);
    }

    public static Result Failure(Error error)
    {
        return new(false, error);
    }

    public static implicit operator Result(Error error)
    {
        return Failure(error);
    }
}
