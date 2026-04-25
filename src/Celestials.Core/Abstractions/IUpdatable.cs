namespace Celestials.Core.Abstractions;

public interface IUpdatable
{
    DateTimeOffset? UpdatedAt { get; }
}
