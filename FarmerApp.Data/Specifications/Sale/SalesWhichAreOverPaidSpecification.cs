using FarmerApp.Data.Entities;
using FarmerApp.Data.Specifications.Common;

namespace FarmerApp.Data.Specifications.Sale
{
    public class SalesWhichAreOverPaidSpecification : BaseSpecification<SaleEntity>
    {
        public SalesWhichAreOverPaidSpecification() : base(x => (x.PriceKG * x.Weight) - x.Paid < 0)
        {
            AddInclude(x => x.Customer);
            AddInclude(x => x.Product);
        }
    }
}
