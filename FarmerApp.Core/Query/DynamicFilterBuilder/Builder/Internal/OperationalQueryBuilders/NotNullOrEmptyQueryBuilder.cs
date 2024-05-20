using System.Linq.Expressions;

namespace FarmerApp.Core.Query.DynamicFilterBuilder.Builder.Internal.OperationalQueryBuilders;

internal class NotNullOrEmptyQueryBuilder : IOperationalQueryBuilder
{
    public static readonly NotNullOrEmptyQueryBuilder Instance = new();

    private NotNullOrEmptyQueryBuilder()
    {
    }

    public Expression Build(Type propertyType, Expression propertyExpression, string filterValue)
    {
        return Expression.Not(NullOrEmptyQueryBuilder.Instance.Build(propertyType, propertyExpression, filterValue));
    }
}