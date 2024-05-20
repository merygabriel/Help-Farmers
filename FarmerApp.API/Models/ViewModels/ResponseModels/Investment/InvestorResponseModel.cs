using FarmerApp.API.Models.ViewModels.ResponseModels.Expense;

namespace FarmerApp.API.Models.ViewModels.ResponseModels.Investment
{
    public class InvestorResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public double? TotalAmountOfExpenses { get; set; }
        public double? TotalAmountOfInvestments { get; set; }

        public IEnumerable<InvestmentResponseModel> Investments { get; set; }
        public IEnumerable<ExpenseResponseModel> Expenses { get; set; }
    }
}

