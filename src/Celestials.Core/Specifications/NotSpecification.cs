namespace Celestials.Core.Specifications;

using Celestials.Core.Utilities;

public sealed class NotSpecification<T> : Specification<T>
{
    private readonly Specification<T> _inner;

    public NotSpecification(Specification<T> inner)
    {
        ArgumentNullException.ThrowIfNull(inner);

        _inner = inner;

        if (inner.Criteria is not null)
        {
            AddCriteria(ExpressionCombiner.Not(inner.Criteria));
        }
    }

    public override bool IsSatisfiedBy(T entity)
    {
        return !_inner.IsSatisfiedBy(entity);
    }
}
