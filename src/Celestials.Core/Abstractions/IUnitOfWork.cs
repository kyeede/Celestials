namespace Celestials.Core.Abstractions;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    Task<ITransactionScope> BeginTransactionAsync(CancellationToken cancellationToken = default);
}
