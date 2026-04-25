using Celestials.Core.Errors;
using Celestials.Core.Results;

namespace Celestials.Core.Extensions;

public static class ResultExtensions
{
    extension<T>(Task<Result<T>> source)
    {
        public async Task<Result<TNext>> MapAsync<TNext>(Func<T, TNext> selector)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(selector);

            var result = await source.ConfigureAwait(false);
            return result.Map(selector);
        }

        public async Task<Result<TNext>> BindAsync<TNext>(Func<T, Task<Result<TNext>>> binder)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(binder);

            var result = await source.ConfigureAwait(false);
            return result switch
            {
                { IsSuccess: true } => await binder(result.Value).ConfigureAwait(false),
                _ => Result<TNext>.Failure(result.Error),
            };
        }
    }

    extension<T>(Result<T> source)
    {
        public Result<TNext> Map<TNext>(Func<T, TNext> selector)
        {
            ArgumentNullException.ThrowIfNull(selector);
            return source switch
            {
                { IsSuccess: true } => Result<TNext>.Success(selector(source.Value)),
                _ => Result<TNext>.Failure(source.Error),
            };
        }

        public Task<Result<TNext>> MapAsync<TNext>(Func<T, TNext> selector)
        {
            ArgumentNullException.ThrowIfNull(selector);
            return Task.FromResult(
                source switch
                {
                    { IsSuccess: true } => Result<TNext>.Success(selector(source.Value)),
                    _ => Result<TNext>.Failure(source.Error),
                }
            );
        }

        public Task<Result<TNext>> BindAsync<TNext>(Func<T, Task<Result<TNext>>> binder)
        {
            ArgumentNullException.ThrowIfNull(binder);
            return source switch
            {
                { IsSuccess: true } => binder(source.Value),
                _ => Task.FromResult(Result<TNext>.Failure(source.Error)),
            };
        }

        public Result<T> TapError(Action<Error> onError)
        {
            ArgumentNullException.ThrowIfNull(onError);
            if (source is { IsFailure: true, Error: var error })
            {
                onError(error);
            }

            return source;
        }

        public Result<T> Tap(Action<T> onSuccess)
        {
            ArgumentNullException.ThrowIfNull(onSuccess);

            if (source is { IsSuccess: true })
            {
                onSuccess(source.Value);
            }

            return source;
        }
    }

    extension(Result source)
    {
        public Result<T> Rewrap<T>()
        {
            if (source is { IsFailure: true })
            {
                return Result<T>.Failure(source.Error);
            }
            else
            {
                throw new InvalidOperationException("Cannot rewrap a successful result without a value.");
            }
        }
    }
}
