namespace Celestials.Core.Entities;

using Celestials.Core.Options;

public interface IUpdatable<TUpdateModel>
    where TUpdateModel : notnull
{
    Task UpdateAsync(TUpdateModel updateModel, RequestOptions? options = null);
}
