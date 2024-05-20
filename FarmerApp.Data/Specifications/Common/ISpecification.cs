using System.Linq.Expressions;

namespace FarmerApp.Data.Specifications.Common
{
    public interface ISpecification<TEntity>
    {
        int Take { get; }
        int Skip { get; }
        bool IsPagingEnabled { get; }

        Expression<Func<TEntity, bool>> Criteria { get; set; }
        List<Expression<Func<TEntity, object>>> Includes { get; }
        List<string> IncludeStrings { get; }
        List<Expression<Func<TEntity, object>>> OrderBy { get; }
        List<Expression<Func<TEntity, object>>> OrderByDescending { get; }
        Expression<Func<TEntity, object>> GroupBy { get; }

        void ApplyPaging(int pageNumber, int pageSize);
    }
}
