namespace Celestials.Core.Contracts;

public interface IValueObject<out TId>
    where TId : struct, IEquatable<TId>
{
    TId Value { get; }
    bool IsEmpty { get; }
}
