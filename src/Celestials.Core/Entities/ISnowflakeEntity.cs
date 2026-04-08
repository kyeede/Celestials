namespace Celestials.Core.Entities;

public interface ISnowflakeEntity : IEntity<ulong>
{
    DateTimeOffset CreatedAt { get; }
}
