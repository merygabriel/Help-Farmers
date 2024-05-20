using FarmerApp.Data.Entities;
using FarmerApp.Data.Specifications.Common;

namespace FarmerApp.Data.Specifications.Investment
{
    public class InvestmentsByInvestorIdSpecification : BaseSpecification<InvestmentEntity>
    {
        public InvestmentsByInvestorIdSpecification(int investorId) : base(x => x.Id == investorId)
        {
            
        }
    }
}
