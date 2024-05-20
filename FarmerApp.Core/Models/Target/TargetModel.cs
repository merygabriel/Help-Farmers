using FarmerApp.Core.Models.Expense;
using FarmerApp.Core.Models.Interfaces;
using FarmerApp.Core.Models.User;

namespace FarmerApp.Core.Models.Target
{
    public class TargetModel : BaseModel, IHasUserModel
    {
        public string Name { get; set; }

        public int? UserId { get; set; }
        public UserModel User { get; set; }

        public List<ExpenseModel> Expenses { get; set; }
    }
}
