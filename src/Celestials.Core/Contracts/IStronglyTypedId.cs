namespace Celestials.Core.Contracts;

public interface IStronglyTypedId<TValue>
    where TValue : struct, IEquatable<TValue>
{
    TValue Value { get; }
}
