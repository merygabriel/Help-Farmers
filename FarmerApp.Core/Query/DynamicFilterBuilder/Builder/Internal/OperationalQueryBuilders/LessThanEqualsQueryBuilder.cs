using System.Linq.Expressions;

namespace FarmerApp.Core.Query.DynamicFilterBuilder.Builder.Internal.OperationalQueryBuilders;

internal class LessThanEqualsQueryBuilder : IOperationalQueryBuilder
{
    public static readonly LessThanEqualsQueryBuilder Instance = new();

    private LessThanEqualsQueryBuilder()
    {
    }


    public Expression Build(Type propertyType, Expression propertyExpression, string filterValue)
    {
        var filterValueExpression = GetValueExpression(propertyType, filterValue);

        var result = Expression.LessThanOrEqual(propertyExpression, filterValueExpression);

        return result;
    }

    private static ConstantExpression GetValueExpression(Type type, string valueString)
    {
        if (type == typeof(int))
            return Expression.Constant(Convert.ToInt32(valueString), typeof(int));
        if (type==typeof(int?))
            return Expression.Constant(Convert.ToInt32(valueString), typeof(int?));
        if (type == typeof(DateTime))
            return Expression.Constant(Convert.ToDateTime(valueString), typeof(DateTime));
        if (type == typeof(DateTime?))
            return Expression.Constant(Convert.ToDateTime(valueString), typeof(DateTime?));
        if (type == typeof(DateTimeOffset))
            return Expression.Constant(new DateTimeOffset(Convert.ToDateTime(valueString), TimeSpan.Zero), typeof(DateTimeOffset));
        if (type == typeof(DateTimeOffset?))
            return Expression.Constant(new DateTimeOffset(Convert.ToDateTime(valueString), TimeSpan.Zero), typeof(DateTimeOffset?));
        if (type == typeof(double))
            return Expression.Constant(Convert.ToDouble(valueString), typeof(double));
        if (type == typeof(double?))
            return Expression.Constant(Convert.ToDouble(valueString), typeof(double?));
        if (type == typeof(decimal))
            return Expression.Constant(Convert.ToDecimal(valueString), typeof(decimal));
        if (type==typeof(decimal?))
            return Expression.Constant(Convert.ToDecimal(valueString), typeof(decimal?));
        throw new NotSupportedException();
    }
}