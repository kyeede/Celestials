namespace Celestials.Core.Specifications;

using System.Linq.Expressions;
using Celestials.Core.Utilities;

public abstract class Specification<T>
{
    private readonly List<Expression<Func<T, object>>> _includes = [];
    private readonly List<string> _includeStrings = [];

    public IReadOnlyList<Expression<Func<T, object>>> Includes => _includes.AsReadOnly();
    public IReadOnlyList<string> IncludeStrings => _includeStrings.AsReadOnly();

    public Expression<Func<T, bool>>? Criteria { get; private set; }
    public Expression<Func<T, object>>? OrderBy { get; private set; }
    public Expression<Func<T, object>>? OrderByDescending { get; private set; }
    public int? Skip { get; private set; }
    public int? Take { get; private set; }
    public bool IsPagingEnabled { get; private set; }
    public bool IsNoTracking { get; private set; }
    public bool IsSplitQuery { get; private set; }

    protected Specification() { }

    protected Specification(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
    }

    protected void AddCriteria(Expression<Func<T, bool>> criteria)
    {
        ArgumentNullException.ThrowIfNull(criteria);
        Criteria = Criteria is null ? criteria : ExpressionCombiner.And(Criteria, criteria);
    }

    protected void AddInclude(Expression<Func<T, object>> includeExpression)
    {
        ArgumentNullException.ThrowIfNull(includeExpression);
        _includes.Add(includeExpression);
    }

    protected void AddInclude(string includeString)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(includeString);
        _includeStrings.Add(includeString);
    }

    protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
    {
        ArgumentNullException.ThrowIfNull(orderByExpression);
        OrderBy = orderByExpression;
        OrderByDescending = null;
    }

    protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression)
    {
        ArgumentNullException.ThrowIfNull(orderByDescendingExpression);
        OrderByDescending = orderByDescendingExpression;
        OrderBy = null;
    }

    protected void ApplyPaging(int pageNumber, int pageSize)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(pageNumber, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(pageSize, 1);

        Skip = (pageNumber - 1) * pageSize;
        Take = pageSize;
        IsPagingEnabled = true;
    }

    protected void AsTracking() => IsNoTracking = false;

    protected void AsSplitQuery() => IsSplitQuery = true;

    public virtual bool IsSatisfiedBy(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        return Criteria?.Compile()(entity) ?? true;
    }

    public static AndSpecification<T> operator &(Specification<T> left, Specification<T> right) =>
        new(left, right);

    public static OrSpecification<T> operator |(Specification<T> left, Specification<T> right) =>
        new(left, right);

    public static NotSpecification<T> operator !(Specification<T> spec) => new(spec);
}
