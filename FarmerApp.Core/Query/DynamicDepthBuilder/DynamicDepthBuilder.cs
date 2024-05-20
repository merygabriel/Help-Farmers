using FarmerApp.Data.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FarmerApp.Core.Query.DynamicDepthBuilder;

public class DynamicDepthBuilder<T> where T : BaseEntity
{
    private int _maxDepth;
    private readonly Type _type;

    public DynamicDepthBuilder()
    {
        _type = typeof(T);
    }

    public IEnumerable<string> Build(int depth, IEnumerable<string> propertyTypesToExclude)
    {
        if (depth < 2)
            return Enumerable.Empty<string>();

        _maxDepth = depth;

        var fieldsToInclude = FindPropertyNamesToInclude(propertyTypesToExclude);

        return fieldsToInclude;
    }

    private ICollection<string> FindPropertyNamesToInclude(IEnumerable<string> propertyTypesToExclude)
    {
        ICollection<string> fieldNamesToInclude = new List<string>();
        var queue = new Queue<(Type type, int depth, string fullPath, Type parentType)>();

        queue.Enqueue((_type, 1, "", null));

        while (queue.Count > 0)
        {
            var (type, depth, fullPath, parentType) = queue.Dequeue();
            if (depth < _maxDepth)
            {
                foreach (var childProp in ParseForeignObjectProperties(type, parentType))
                {
                    if (propertyTypesToExclude is not null && propertyTypesToExclude.Contains(childProp.PropertyType.Name))
                        continue;

                    var childFullPath = string.Join('.', fullPath, childProp.Name);
                    childFullPath = childFullPath.StartsWith('.') ? childFullPath[1..] : childFullPath;

                    fieldNamesToInclude.Add(childFullPath);
                    queue.Enqueue((ParsePropertyActualType(childProp), depth + 1, childFullPath, type)!);
                }
            }
        }

        return fieldNamesToInclude;
    }

    private static IEnumerable<PropertyInfo> ParseForeignObjectProperties(Type type, Type parentType = null)
    {
        return type.GetProperties().Where(x => x.PropertyType.IsSubclassOf(typeof(DbEntity)) ||
                                               x.PropertyType.GetGenericArguments()
                                                   .Any(t => t.IsSubclassOf(typeof(DbEntity))))
            .Where(x => ParsePropertyActualType(x) != parentType)
            .ToList();
    }

    private static Type ParsePropertyActualType(PropertyInfo pInfo)
    {
        if (pInfo.PropertyType.IsSubclassOf(typeof(DbEntity)))
            return pInfo.PropertyType;

        if (pInfo.PropertyType.GetGenericArguments().Any(t => t.IsSubclassOf(typeof(DbEntity))))
            return pInfo.PropertyType.GetGenericArguments().First(x => x.IsSubclassOf(typeof(DbEntity)));

        return default;
    }
}