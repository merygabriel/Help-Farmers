using System.Linq.Expressions;
using System.Reflection;

namespace FarmerApp.Core.Query.DynamicFilterBuilder.Builder.Internal.OperationalQueryBuilders;

internal class NullOrEmptyQueryBuilder : IOperationalQueryBuilder
{
    public static readonly NullOrEmptyQueryBuilder Instance = new();

    private NullOrEmptyQueryBuilder()
    {
    }


    public Expression Build(Type propertyType, Expression propertyExpression, string filterValue)
    {
        if (propertyType != typeof(string))
            throw new InvalidOperationException();

        var method = GetIsNullOrEmptyMethod();

        var callExpression = Expression.Call(null, method, propertyExpression);

        return callExpression;
    }

    private static MethodInfo GetIsNullOrEmptyMethod()
    {
        return typeof(string).GetMethod("IsNullOrEmpty",
            BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)!;
    }
}