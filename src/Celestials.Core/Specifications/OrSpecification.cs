namespace Celestials.Core.Specifications;

using Celestials.Core.Utilities;

public sealed class OrSpecification<T> : Specification<T>
{
    private readonly Specification<T> _left;
    private readonly Specification<T> _right;

    public OrSpecification(Specification<T> left, Specification<T> right)
    {
        ArgumentNullException.ThrowIfNull(left);
        ArgumentNullException.ThrowIfNull(right);

        _left = left;
        _right = right;

        if (left.Criteria is not null && right.Criteria is not null)
        {
            AddCriteria(ExpressionCombiner.Or(left.Criteria, right.Criteria));
        }
        else if (left.Criteria is not null)
        {
            AddCriteria(left.Criteria);
        }
        else if (right.Criteria is not null)
        {
            AddCriteria(right.Criteria);
        }
    }

    public override bool IsSatisfiedBy(T entity)
    {
        return _left.IsSatisfiedBy(entity) || _right.IsSatisfiedBy(entity);
    }
}
