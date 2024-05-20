using FarmerApp.Core.Models.Expense;
using FarmerApp.Core.Models.Interfaces;
using FarmerApp.Core.Models.User;

namespace FarmerApp.Core.Models.Investment;

public class InvestorModel : BaseModel, IHasUserModel
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }

    public double? TotalAmountOfInvestments { get; set; }
    public double? TotalAmountOfExpenses { get; set; }

    public int? UserId { get; set; }
    public UserModel User { get; set; }

    public IEnumerable<InvestmentModel> Investments { get; set; }
    public IEnumerable<ExpenseModel> Expenses { get; set; }
}

