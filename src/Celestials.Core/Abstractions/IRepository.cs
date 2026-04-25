using System.Linq.Expressions;
using Celestials.Core.Utilities.Paging;

namespace Celestials.Core.Abstractions;

public interface IRepository<T>
    where T : class, IEntity<ulong>
{
    Task<T?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default);

    Task<T?> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

    Task<bool> ExistsAsync(ulong id, CancellationToken cancellationToken = default);

    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

    Task<PagedResult<T>> PageAsync(PageRequest request, CancellationToken cancellationToken = default);

    Task<PagedResult<T>> PageAsync(Expression<Func<T, bool>> predicate, PageRequest request, CancellationToken cancellationToken = default);

    Task AddAsync(T entity, CancellationToken cancellationToken = default);

    void Update(T entity);

    void Delete(T entity);
}
