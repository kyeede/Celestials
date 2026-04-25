namespace Celestials.Core.Abstractions;

public interface IDeletable
{
    DateTimeOffset? DeletedAt { get; }
}
