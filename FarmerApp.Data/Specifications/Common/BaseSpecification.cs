using System.Linq.Expressions;

namespace FarmerApp.Data.Specifications.Common
{
    public class BaseSpecification<TEntity> : ISpecification<TEntity>
    {
        #region Constructors
        protected BaseSpecification(Expression<Func<TEntity, bool>> criteria)
        {
            Criteria = criteria;
        }
        protected BaseSpecification()
        {
        }
        #endregion

        #region Properties
        public Expression<Func<TEntity, bool>> Criteria { get; set; }

        public List<Expression<Func<TEntity, object>>> Includes { get; } = new();
        public List<string> IncludeStrings { get; } = new List<string>();

        public List<Expression<Func<TEntity, object>>> OrderBy { get; private set; } = new();
        public List<Expression<Func<TEntity, object>>> OrderByDescending { get; private set; } = new();

        public Expression<Func<TEntity, object>> GroupBy { get; private set; }

        public int Take { get; private set; }
        public int Skip { get; private set; }
        public bool IsPagingEnabled { get; private set; } = false;
        #endregion

        #region Methods 
        public virtual void ApplyPaging(int pageNumber, int pageSize)
        {
            Skip = (pageNumber - 1) * pageSize;
            Take = pageSize;
            IsPagingEnabled = true;
        }

        protected virtual void AddInclude(Expression<Func<TEntity, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected virtual void AddInclude(string includeString)
        {
            IncludeStrings.Add(includeString);
        }

        protected virtual void ApplyOrderBy(Expression<Func<TEntity, object>> orderByExpression)
        {
            OrderBy.Add(orderByExpression);
        }

        protected virtual void ApplyOrderByDescending(Expression<Func<TEntity, object>> orderByDescendingExpression)
        {
            OrderByDescending.Add(orderByDescendingExpression);
        }

        protected virtual void ApplyGroupBy(Expression<Func<TEntity, object>> groupByExpression)
        {
            GroupBy = groupByExpression;
        }
        #endregion
    }
}
