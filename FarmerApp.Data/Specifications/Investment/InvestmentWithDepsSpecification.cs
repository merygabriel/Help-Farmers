using FarmerApp.Data.Entities;
using FarmerApp.Data.Specifications.Common;

namespace FarmerApp.Data.Specifications.Investment
{
    public class InvestmentWithDepsSpecification : BaseSpecification<InvestmentEntity>
    {
        public InvestmentWithDepsSpecification()
        {
            AddInclude(x => x.Investor);
        }
    }
}
