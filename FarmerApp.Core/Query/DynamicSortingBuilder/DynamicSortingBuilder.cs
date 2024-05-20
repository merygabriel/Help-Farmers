using System.Linq.Expressions;
using System.Reflection;

namespace FarmerApp.Core.Query.DynamicSortingBuilder;

public static class DynamicSortingBuilder
{
    public static List<Expression<Func<TSource, object>>> BuildOrderingFunc<TSource>(
        IEnumerable<OrderingItem> orderings)
    {
        List<Expression<Func<TSource, object>>> result = new();

        var localParameterExpression = Expression.Parameter(typeof(TSource), "x");

        var type = typeof(TSource);
        var typeProperties = type.GetProperties();

        foreach (var ordering in orderings)
        {
            MemberExpression memberExpression = null!;

            var currentTypeProperties = typeProperties;
            PropertyInfo propertyInfo = null!;
            foreach (var propertyName in ordering.Property.Split('.'))
            {
                propertyInfo = currentTypeProperties.FirstOrDefault(x => x.Name.ToLower() == propertyName.ToLower())!;

                currentTypeProperties = propertyInfo.PropertyType.GetProperties();

                Expression memberBefore = memberExpression == null ? localParameterExpression : memberExpression;

                memberExpression = Expression.PropertyOrField(memberBefore, propertyName);
            }

            result.Add(Expression.Lambda<Func<TSource, object>>(
                Expression.Convert(memberExpression, typeof(object)),
                localParameterExpression
            ));
        }

        return result;
    }
}