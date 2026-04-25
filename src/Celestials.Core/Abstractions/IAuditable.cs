namespace Celestials.Core.Abstractions;

public interface IAuditable : ICreatable, IUpdatable, IDeletable
{
    ulong CreatedBy { get; }
    ulong? UpdatedBy { get; }
    ulong? DeletedBy { get; }
}
