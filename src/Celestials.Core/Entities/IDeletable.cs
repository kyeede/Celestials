namespace Celestials.Core.Entities;

using Celestials.Core.Options;

public interface IDeletable
{
    Task DeleteAsync(RequestOptions? options = null);
}
