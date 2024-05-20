using FarmerApp.Core.Models.Interfaces;
using FarmerApp.Core.Models.Investment;
using FarmerApp.Core.Models.Target;
using FarmerApp.Core.Models.User;

namespace FarmerApp.Core.Models.Expense
{
    public class ExpenseModel : BaseModel, IHasUserModel
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public DateTime? Date { get; set; }

        public int TargetId { get; set; }
        public TargetModel Target { get; set; }

        public int InvestorId { get; set; }
        public InvestorModel Investor { get; set; }

        public int? UserId { get; set; }
        public UserModel User { get; set; }
    }
}

