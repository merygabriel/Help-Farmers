using FarmerApp.Data.Entities;
using FarmerApp.Data.Specifications.Common;
using System.Linq.Expressions;

namespace FarmerApp.Data.Specifications.Expense
{
    public class ExpensesWithDepsSpecification : BaseSpecification<ExpenseEntity>
    {
        protected ExpensesWithDepsSpecification() : base()
        {
            AddIncludes();
        }

        protected ExpensesWithDepsSpecification(Expression<Func<ExpenseEntity, bool>> criteria) : base(criteria)
        {
            AddIncludes();
        }

        private void AddIncludes()
        {
            AddInclude(x => x.Target);
        }
    }
}
