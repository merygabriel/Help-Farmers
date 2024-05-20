using FarmerApp.Data.Entities;
using FarmerApp.Data.Specifications.Common;

namespace FarmerApp.Data.Specifications.Expense
{
    public class ExpensesByInvestorIdSpecification : BaseSpecification<ExpenseEntity>
    {
        public ExpensesByInvestorIdSpecification(int investorId) : base(x => x.Id == investorId)
        {

        }
    }
}
