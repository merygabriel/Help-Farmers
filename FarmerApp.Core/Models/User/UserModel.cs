using FarmerApp.Core.Models.Customer;
using FarmerApp.Core.Models.Expense;
using FarmerApp.Core.Models.Investment;
using FarmerApp.Core.Models.Product;
using FarmerApp.Core.Models.Sale;
using FarmerApp.Core.Models.Treatment;

namespace FarmerApp.Core.Models.User
{
    public class UserModel : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }

        public IEnumerable<ProductModel> Products { get; set; }
        public IEnumerable<CustomerModel> Customers { get; set; }
        public IEnumerable<ExpenseModel> Expenses { get; set; }
        public IEnumerable<InvestorModel> Investors { get; set; }
        public IEnumerable<SaleModel> Sales { get; set; }
        public IEnumerable<TreatmentModel> Treatments { get; set; }
    }
}
