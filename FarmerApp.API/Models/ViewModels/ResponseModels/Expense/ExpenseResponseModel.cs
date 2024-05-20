using FarmerApp.API.Models.ViewModels.ResponseModels.Investment;
using FarmerApp.API.Models.ViewModels.ResponseModels.Target;

namespace FarmerApp.API.Models.ViewModels.ResponseModels.Expense
{
    public class ExpenseResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public DateTime? Date { get; set; }

        public InvestorResponseModel Investor { get; set; }
        public TargetResponseModel Target { get; set; }
    }
}

