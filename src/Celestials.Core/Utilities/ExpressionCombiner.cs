namespace Celestials.Core.Utilities;

using System.Linq.Expressions;

internal static class ExpressionCombiner
{
    public static Expression<Func<T, bool>> And<T>(
        Expression<Func<T, bool>> left,
        Expression<Func<T, bool>> right
    )
    {
        var rightBody = ReplaceParameter(right.Body, right.Parameters[0], left.Parameters[0]);

        return Expression.Lambda<Func<T, bool>>(
            Expression.AndAlso(left.Body, rightBody),
            left.Parameters[0]
        );
    }

    public static Expression<Func<T, bool>> Or<T>(
        Expression<Func<T, bool>> left,
        Expression<Func<T, bool>> right
    )
    {
        var rightBody = ReplaceParameter(right.Body, right.Parameters[0], left.Parameters[0]);

        return Expression.Lambda<Func<T, bool>>(
            Expression.OrElse(left.Body, rightBody),
            left.Parameters[0]
        );
    }

    public static Expression<Func<T, bool>> Not<T>(Expression<Func<T, bool>> expression)
    {
        return Expression.Lambda<Func<T, bool>>(
            Expression.Not(expression.Body),
            expression.Parameters[0]
        );
    }

    private static Expression ReplaceParameter(
        Expression body,
        ParameterExpression source,
        ParameterExpression target
    )
    {
        return new ParameterReplacer(source, target).Visit(body);
    }

    private sealed class ParameterReplacer(ParameterExpression source, ParameterExpression target)
        : ExpressionVisitor
    {
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return node == source ? target : base.VisitParameter(node);
        }
    }
}
