using System.Linq.Expressions;
using System.Reflection;

namespace FarmerApp.Core.Query.DynamicFilterBuilder.Builder.Internal.OperationalQueryBuilders;

internal class LikeQueryBuilder : IOperationalQueryBuilder
{
    public static readonly LikeQueryBuilder Instance = new();


    private static readonly Type _stringType = typeof(string);

    private LikeQueryBuilder()
    {
    }


    public Expression Build(Type propertyType, Expression propertyExpression, string filterValue)
    {
        if (propertyType != _stringType)
            throw new InvalidOperationException();

        var containsMethod = GetContainsMethod();
        var filterValueExpression = GetValueExpression(filterValue);

        var containsCallExpression = Expression.Call(propertyExpression, containsMethod, filterValueExpression);

        return containsCallExpression;
    }

    private static MethodInfo GetContainsMethod()
    {
        return _stringType.GetMethod("Contains", new[] { _stringType })!;
    }

    private ConstantExpression GetValueExpression(string valueString)
    {
        return Expression.Constant(valueString, typeof(string));
    }
}