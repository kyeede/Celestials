namespace Celestials.Core.Entities;

using Celestials.Core.Options;

public interface ICreatable<TCreateModel, TEntity>
    where TCreateModel : notnull
    where TEntity : notnull
{
    Task<TEntity> CreateAsync(TCreateModel createModel, RequestOptions? options = null);
}
