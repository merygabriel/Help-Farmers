using System.Linq.Expressions;
using System.Reflection;
using Newtonsoft.Json;

namespace FarmerApp.Core.Query.DynamicFilterBuilder.Builder.Internal.OperationalQueryBuilders;

internal class InQueryBuilder : IOperationalQueryBuilder
{
    public static readonly InQueryBuilder Instance = new();

    private InQueryBuilder()
    {
    }

    public Expression Build(Type propertyType, Expression propertyExpression, string filterValue)
    {
        if ((propertyType != typeof(int) && propertyType != typeof(int?))
            && (propertyType != typeof(bool) && propertyType != typeof(bool?)))
            throw new InvalidOperationException();

        if (propertyType == typeof(int?))
            propertyExpression = Expression.PropertyOrField(propertyExpression, nameof(Nullable<int>.Value));

        var containsMethod = GetContainsMethod(propertyType);
        var filterValueExpression = GetValueExpression(propertyType, filterValue);

        var containsCallExpression = Expression.Call(filterValueExpression, containsMethod, propertyExpression);

        return containsCallExpression;
    }   

    private static MethodInfo GetContainsMethod(Type type)
    {
        MethodInfo method = default;

        if (type.Equals(typeof(int)) || type.Equals(typeof(int?)))
            method = typeof(List<int>).GetMethod("Contains", new[] { typeof(int) })!;

        else if (type.Equals(typeof(bool)) || type.Equals(typeof(bool?)))
            method = typeof(List<bool?>).GetMethod("Contains", new[] { typeof(bool?) })!;

        return method;
    }

    private static ConstantExpression GetValueExpression(Type type, string valueString)
    {
        if (type == typeof(int) || type == typeof(int?))
            return Expression.Constant(JsonConvert.DeserializeObject<List<int>>(valueString), typeof(List<int>));

        else if (type == typeof(bool) || type == typeof(bool?))
            return Expression.Constant(JsonConvert.DeserializeObject<List<bool?>>(valueString), typeof(List<bool?>));

        throw new NotSupportedException();
    }
}