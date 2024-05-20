using System.Linq.Expressions;

namespace FarmerApp.Core.Query.DynamicFilterBuilder.Builder.Internal;

internal interface IOperationalQueryBuilder
{
    Expression Build(Type propertyType, Expression propertyExpression, string filterValue);
}