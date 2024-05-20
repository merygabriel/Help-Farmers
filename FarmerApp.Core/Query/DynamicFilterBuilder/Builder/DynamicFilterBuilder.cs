using System.Linq.Expressions;
using System.Reflection;
using FarmerApp.Core.Query.DynamicFilterBuilder.Builder.Internal;
using FarmerApp.Core.Query.DynamicFilterBuilder.Builder.Internal.OperationalQueryBuilders;
using FarmerApp.Core.Query.Enums;

namespace FarmerApp.Core.Query.DynamicFilterBuilder.Builder;

public class DynamicFilterBuilder<T>
{
    private static readonly DynamicFilterBuilder<T> dynamicFilterBuilder = new();
    private readonly PropertyInfo[] _properties;
    private readonly Type _type;

    public static DynamicFilterBuilder<T> Instance = dynamicFilterBuilder;

    private DynamicFilterBuilder()
    {
        _type = typeof(T);
        _properties = _type.GetProperties();
    }

    public Expression<Func<T, bool>> BuildFilter(IEnumerable<FilteringItem> filters, bool matchAny)
    {
        Expression finalFilter = Expression.Constant(!matchAny);

        var parameterExpression = Expression.Parameter(_type, "x");

        foreach (var filter in filters)
        {
            var (propertyType, propertyExpression) =
                GetPropertyTypeWithExpression(parameterExpression, filter.Property);

            var operationalQueryBuilder = GetOperationalQueryBuilder(filter.Operation);

            var result = operationalQueryBuilder.Build(propertyType, propertyExpression, filter.Value);

            if (matchAny)
                finalFilter = Expression.Or(finalFilter, result);
            else
                finalFilter = Expression.And(finalFilter, result);
        }

        return Expression.Lambda<Func<T, bool>>(finalFilter, parameterExpression);
    }
       
    private (Type propertyType, Expression propertyExpression) GetPropertyTypeWithExpression(
        ParameterExpression parameterExpression, string propertyName)
    {
        var propertyInfo = _properties.FirstOrDefault(f => f.Name.ToLower() == propertyName.ToLower());

        Type _propertyType;
        Expression _propertyExpression;

        if (propertyInfo != null)
        {
            _propertyType = propertyInfo.PropertyType;
            _propertyExpression = Expression.Property(parameterExpression, propertyInfo.Name);
        }
        else
        {
            _propertyExpression = propertyName
                .Split('.')
                .Aggregate<string, Expression>(parameterExpression, Expression.PropertyOrField!);


            _propertyType = _propertyExpression
                .ToString()
                .Split('.')
                .Skip(1)
                .Aggregate(_type, (t, s) => t.GetProperty(s)!.PropertyType);
        }

        return (_propertyType, _propertyExpression);
    }


    private static IOperationalQueryBuilder GetOperationalQueryBuilder(string operation)
    {
        return operation switch
        {
            Operations.EqualTo => EqualsQueryBuilder.Instance,
            Operations.NotEqual => NotEqualsQueryBuilder.Instance,
            Operations.Like => LikeQueryBuilder.Instance,
            Operations.GreaterThan => GreaterThanQueryBuilder.Instance,
            Operations.GreaterThanOrEqualTo => GreaterThanEqualsQueryBuilder.Instance,
            Operations.LessThan => LessThanQueryBuilder.Instance,
            Operations.LessThanOrEqualTo => LessThanEqualsQueryBuilder.Instance,
            Operations.In => InQueryBuilder.Instance,
            Operations.NotIn => NotInQueryBuilder.Instance,
            Operations.NullOrEmpty => NullOrEmptyQueryBuilder.Instance,
            Operations.NotNullOrEmpty => NotNullOrEmptyQueryBuilder.Instance,
            _ => throw new NotImplementedException()
        };
    }
}