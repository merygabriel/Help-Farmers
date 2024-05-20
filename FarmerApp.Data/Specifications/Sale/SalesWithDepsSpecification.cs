using FarmerApp.Data.Entities;
using FarmerApp.Data.Specifications.Common;
using System.Linq.Expressions;

namespace FarmerApp.Data.Specifications.Sale
{
    public class SalesWithDepsSpecification : BaseSpecification<SaleEntity>
    {
        protected SalesWithDepsSpecification() : base()
        {
            AddIncludes();
        }

        protected SalesWithDepsSpecification(Expression<Func<SaleEntity, bool>> criteria) : base(criteria)
        {
            AddIncludes();
        }

        private void AddIncludes()
        {
            AddInclude(x => x.Product);
            AddInclude(x => x.Customer);
        }
    }
}
