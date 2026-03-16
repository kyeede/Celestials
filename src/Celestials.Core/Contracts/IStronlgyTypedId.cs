namespace Celestials.Core.Contracts;

public interface IStronlgyTypedId<TId>
    where TId : struct, IEquatable<TId>
{
    TId Id { get; }
}
