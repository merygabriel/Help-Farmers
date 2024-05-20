using System.Linq.Expressions;

namespace FarmerApp.Core.Query.DynamicFilterBuilder.Builder.Internal.OperationalQueryBuilders;

internal class NotEqualsQueryBuilder : IOperationalQueryBuilder
{
    public static readonly NotEqualsQueryBuilder Instance = new();

    private NotEqualsQueryBuilder()
    {
    }

    public Expression Build(Type propertyType, Expression propertyExpression, string filterValue)
    {
        return Expression.Not(EqualsQueryBuilder.Instance.Build(propertyType, propertyExpression, filterValue));
    }
}