using System.Linq.Expressions;
using Celestials.Core.Abstractions;
using Celestials.Core.Utilities.Paging;
using Microsoft.EntityFrameworkCore;

namespace Celestials.Infrastructure.Persistence.Repositories;

internal abstract class Repository<T> : IRepository<T>
    where T : class, IEntity<ulong>
{
    protected readonly AppDbContext DbContext;
    protected readonly DbSet<T> DbSet;

    protected Repository(AppDbContext dbContext)
    {
        DbContext = dbContext;
        DbSet = dbContext.Set<T>();
    }

    public virtual async Task<T?> GetByIdAsync(ulong id, CancellationToken cancellationToken = default)
    {
        return await DbSet.FirstOrDefaultAsync(e => e.Id == id, cancellationToken).ConfigureAwait(false);
    }

    public virtual async Task<T?> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return await DbSet.FirstOrDefaultAsync(predicate, cancellationToken).ConfigureAwait(false);
    }

    public virtual async Task<bool> ExistsAsync(ulong id, CancellationToken cancellationToken = default)
    {
        return await DbSet.AnyAsync(e => e.Id == id, cancellationToken).ConfigureAwait(false);
    }

    public virtual async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return await DbSet.AnyAsync(predicate, cancellationToken).ConfigureAwait(false);
    }

    public virtual Task<PagedResult<T>> PageAsync(PageRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        return PageCoreAsync(DbSet.AsNoTracking(), request, cancellationToken);
    }

    public virtual Task<PagedResult<T>> PageAsync(
        Expression<Func<T, bool>> predicate,
        PageRequest request,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(request);
        return PageCoreAsync(DbSet.AsNoTracking().Where(predicate), request, cancellationToken);
    }

    public virtual async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(entity);
        await DbSet.AddAsync(entity, cancellationToken).ConfigureAwait(false);
    }

    public virtual void Update(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        DbSet.Update(entity);
    }

    public virtual void Delete(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        DbSet.Remove(entity);
    }

    private static async Task<PagedResult<T>> PageCoreAsync(IQueryable<T> query, PageRequest request, CancellationToken cancellationToken)
    {
        var totalCount = await query.CountAsync(cancellationToken).ConfigureAwait(false);

        if (totalCount is 0)
        {
            return PagedResult<T>.Empty(request);
        }

        var items = await query
            .OrderByDescending(x => x.Id)
            .Skip(request.Skip)
            .Take(request.Take)
            .ToArrayAsync(cancellationToken)
            .ConfigureAwait(false);

        return new PagedResult<T>(items, totalCount, request);
    }
}
