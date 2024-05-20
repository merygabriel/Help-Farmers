using System.Linq.Expressions;
using System.Reflection;

namespace FarmerApp.Core.Query.DynamicFilterBuilder.Builder.Internal.OperationalQueryBuilders;

internal class EqualsQueryBuilder : IOperationalQueryBuilder
{
    public static readonly EqualsQueryBuilder Instance = new();

    private EqualsQueryBuilder()
    {
    }

    public Expression Build(Type propertyType, Expression propertyExpression, string filterValue)
    {
        var equalsMethod = FindOptimalEqualsMethod(propertyType);
        var filterValueExpression = GetValueExpression(propertyType, filterValue);
        var equalsCallExpression = Expression.Call(propertyExpression, equalsMethod, filterValueExpression);

        return equalsCallExpression;
    }

    private Expression GetValueExpression(Type type, string valueString)
    {
        if (type == typeof(string))
            return Expression.Constant(valueString, typeof(string));
        if (type == typeof(int))
            return Expression.Constant(Convert.ToInt32(valueString), typeof(int));
        if (type == typeof(int?))
            return Expression.Constant(Convert.ToInt32(valueString), typeof(object));
        if (type == typeof(DateTime))
            return Expression.Constant(Convert.ToDateTime(valueString), typeof(DateTime));
        if (type == typeof(DateTime?))
            return Expression.Constant(Convert.ToDateTime(valueString), typeof(object));
        if (type == typeof(DateTimeOffset))
            return Expression.Constant(new DateTimeOffset(Convert.ToDateTime(valueString), TimeSpan.Zero), typeof(DateTimeOffset));
        if (type == typeof(DateTimeOffset?))
            return Expression.Constant(new DateTimeOffset(Convert.ToDateTime(valueString), TimeSpan.Zero), typeof(object));
        if (type == typeof(double))
            return Expression.Constant(Convert.ToDouble(valueString), typeof(double));
        if (type == typeof(double?))
            return Expression.Constant(Convert.ToDouble(valueString), typeof(object));
        if (type == typeof(decimal))
            return Expression.Constant(Convert.ToDecimal(valueString), typeof(decimal));
        if (type == typeof(decimal?))
            return Expression.Constant(Convert.ToDecimal(valueString), typeof(object));
        if (type == typeof(bool))
            return Expression.Constant(Convert.ToBoolean(valueString), typeof(bool));
        if (type == typeof(bool?))
            return Expression.Constant(Convert.ToBoolean(valueString), typeof(object));
        if (type.IsEnum)
            return Expression.Constant(Enum.Parse(type, valueString), typeof(object));

        throw new NotSupportedException();
    }

    private static MethodInfo FindOptimalEqualsMethod(Type propertyType)
    {
        if (propertyType.IsEnum)
            return propertyType.GetMethod("Equals", new[] { propertyType })!;

        if (propertyType.GetInterfaces().Any(i => i.IsGenericType &&
                                                  i.GetGenericTypeDefinition() == typeof(IEquatable<>)))
            return propertyType.GetMethod("Equals", new[] { propertyType })!;

        return propertyType.GetMethod("Equals", new[] { typeof(object) })!;
    }
}