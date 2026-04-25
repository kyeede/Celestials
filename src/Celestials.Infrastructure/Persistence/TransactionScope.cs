using Celestials.Core.Abstractions;
using Microsoft.EntityFrameworkCore.Storage;

namespace Celestials.Infrastructure.Persistence;

internal sealed class TransactionScope(IDbContextTransaction transaction) : ITransactionScope
{
    private bool _completed;

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        if (_completed)
        {
            return;
        }

        await transaction.CommitAsync(cancellationToken).ConfigureAwait(false);
        _completed = true;
    }

    public async ValueTask DisposeAsync()
    {
        if (!_completed)
        {
            await transaction.RollbackAsync().ConfigureAwait(false);
        }

        await transaction.DisposeAsync().ConfigureAwait(false);
    }

    public async Task RollbackAsync(CancellationToken cancellationToken = default)
    {
        if (_completed)
        {
            return;
        }

        await transaction.RollbackAsync(cancellationToken).ConfigureAwait(false);
        _completed = true;
    }
}
