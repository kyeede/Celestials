namespace Celestials.Core.Extensions;

using Celestials.Core.Errors;
using Celestials.Core.Results;

public static class ResultExtensions
{
    extension(Result result)
    {
        public Result Bind(Func<Result> next)
        {
            ArgumentNullException.ThrowIfNull(next);

            if (result.IsFailure)
            {
                return result;
            }

            return next();
        }

        public Result Tap(Action action)
        {
            ArgumentNullException.ThrowIfNull(action);

            if (result.IsSuccess)
            {
                action();
            }

            return result;
        }

        public Result TapError(Action<Error> action)
        {
            ArgumentNullException.ThrowIfNull(action);

            if (result.IsFailure)
            {
                action(result.Error);
            }

            return result;
        }

        public async Task<Result> BindAsync(Func<Task<Result>> next)
        {
            ArgumentNullException.ThrowIfNull(next);

            if (result.IsFailure)
            {
                return result;
            }

            return await next().ConfigureAwait(false);
        }
    }

    extension<T>(Result<T> result)
    {
        public Result<TOut> Bind<TOut>(Func<T, Result<TOut>> next)
        {
            ArgumentNullException.ThrowIfNull(next);

            if (result.IsFailure)
            {
                return Result<TOut>.Failure(result.Error);
            }

            return next(result.Value);
        }

        public Result Bind(Func<T, Result> next)
        {
            ArgumentNullException.ThrowIfNull(next);

            if (result.IsFailure)
            {
                return Result.Failure(result.Error);
            }

            return next(result.Value);
        }

        public Result<TOut> Map<TOut>(Func<T, TOut> mapper)
        {
            ArgumentNullException.ThrowIfNull(mapper);

            if (result.IsFailure)
            {
                return Result<TOut>.Failure(result.Error);
            }

            return Result<TOut>.Success(mapper(result.Value));
        }

        public Result<T> Tap(Action<T> action)
        {
            ArgumentNullException.ThrowIfNull(action);

            if (result.IsSuccess)
            {
                action(result.Value);
            }

            return result;
        }

        public Result<T> TapError(Action<Error> action)
        {
            ArgumentNullException.ThrowIfNull(action);

            if (result.IsFailure)
            {
                action(result.Error);
            }

            return result;
        }

        public Result<T> Ensure(Func<T, bool> predicate, Error error)
        {
            ArgumentNullException.ThrowIfNull(predicate);

            if (result.IsFailure)
            {
                return result;
            }

            if (!predicate(result.Value))
            {
                return Result<T>.Failure(error);
            }

            return result;
        }

        public async Task<Result<TOut>> BindAsync<TOut>(Func<T, Task<Result<TOut>>> next)
        {
            ArgumentNullException.ThrowIfNull(next);

            if (result.IsFailure)
            {
                return Result<TOut>.Failure(result.Error);
            }

            return await next(result.Value).ConfigureAwait(false);
        }

        public async Task<Result<T>> TapAsync(Func<T, Task> action)
        {
            ArgumentNullException.ThrowIfNull(action);

            if (result.IsSuccess)
            {
                await action(result.Value).ConfigureAwait(false);
            }

            return result;
        }

        public async Task<Result<T>> EnsureAsync(Func<T, Task<bool>> predicate, Error error)
        {
            ArgumentNullException.ThrowIfNull(predicate);

            if (result.IsFailure)
            {
                return result;
            }

            if (!await predicate(result.Value).ConfigureAwait(false))
            {
                return Result<T>.Failure(error);
            }

            return result;
        }
    }
}
