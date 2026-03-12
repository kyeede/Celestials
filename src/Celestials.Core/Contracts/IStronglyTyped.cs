namespace Celestials.Core.Contracts;

public interface IStronglyTyped<TSelf, TValue>
    where TSelf : struct, IStronglyTyped<TSelf, TValue>
    where TValue : struct, IEquatable<TValue>
{
    TValue Value { get; }
    static abstract TSelf Empty { get; }
}
