namespace Celestials.Core.Results;

using Celestials.Core.Errors;

public readonly record struct Result<T>
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    public T? Value
    {
        get
        {
            if (IsFailure)
            {
                throw new InvalidOperationException(
                    "Cannot access Value when Result is a failure."
                );
            }

            if (field is null)
            {
                throw new InvalidOperationException("Value is not initialized.");
            }

            return field;
        }
    }

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

    internal Result(T value)
    {
        IsSuccess = true;
        Value = value;
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
        Value = default;
        Error = error;
    }

    public static implicit operator bool(Result<T> result) => result.IsFailure;

    public static implicit operator Result<T>(T value) => new(value);

    public static implicit operator Result<T>(Error error) => new(error);

    public override string ToString() => IsSuccess ? $"Success: {Value}" : $"Failure: {Error}";
}
