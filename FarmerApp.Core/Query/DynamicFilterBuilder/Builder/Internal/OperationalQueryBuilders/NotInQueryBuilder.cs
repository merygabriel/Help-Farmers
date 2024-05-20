using System.Linq.Expressions;

namespace FarmerApp.Core.Query.DynamicFilterBuilder.Builder.Internal.OperationalQueryBuilders;

internal class NotInQueryBuilder : IOperationalQueryBuilder
{
    public static readonly NotInQueryBuilder Instance = new();

    private NotInQueryBuilder()
    {
    }


    public Expression Build(Type propertyType, Expression propertyExpression, string filterValue)
    {
        return Expression.Not(InQueryBuilder.Instance.Build(propertyType, propertyExpression, filterValue));
    }
}