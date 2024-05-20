using Microsoft.EntityFrameworkCore;
using FarmerApp.Data.Entities.Base;
using FarmerApp.Data.Specifications.Common;
using Microsoft.EntityFrameworkCore.Query.Internal;
using FarmerApp.Data.Entities;

namespace FarmerApp.Data.Specifications
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specification)
        {
            var query = ApplyCriteria(inputQuery, specification);
            query = ApplyIncludes(query, specification);
            query = ApplyOrdering(query, specification);
            query = ApplyGrouping(query, specification);
            query = ApplyPaging(query, specification);

            return query;
        }

        private static IQueryable<TEntity> ApplyCriteria(IQueryable<TEntity> query, ISpecification<TEntity> specification)
        {
            return specification.Criteria != null ? query.Where(specification.Criteria) : query;
        }

        private static IQueryable<TEntity> ApplyIncludes(IQueryable<TEntity> query, ISpecification<TEntity> specification)
        {
            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));
            query = specification.IncludeStrings.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }

        private static IQueryable<TEntity> ApplyOrdering(IQueryable<TEntity> query, ISpecification<TEntity> specification)
        {
            if (specification.OrderBy.Any())
            {
                var isFirst = true;

                foreach (var item in specification.OrderBy)
                {
                    query = isFirst ? query.OrderBy(item) : ((IOrderedQueryable<TEntity>)query).ThenBy(item);
                    isFirst = false;
                }
            }
            else if (specification.OrderByDescending.Any())
            {
                var isFirst = true;

                foreach (var item in specification.OrderByDescending)
                {
                    query = isFirst ? query.OrderByDescending(item) : ((IOrderedQueryable<TEntity>)query).ThenByDescending(item);
                    isFirst = false;
                }
            }

            return query;
        }

        private static IQueryable<TEntity> ApplyGrouping(IQueryable<TEntity> query, ISpecification<TEntity> specification)
        {
            return specification.GroupBy != null ? query.GroupBy(specification.GroupBy).SelectMany(x => x) : query;
        }

        private static IQueryable<TEntity> ApplyPaging(IQueryable<TEntity> query, ISpecification<TEntity> specification)
        {
            return specification.IsPagingEnabled ? query.Skip(specification.Skip).Take(specification.Take) : query;
        }

    }
}
