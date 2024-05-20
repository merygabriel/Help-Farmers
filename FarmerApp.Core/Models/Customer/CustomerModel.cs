using FarmerApp.Core.Models.Interfaces;
using FarmerApp.Core.Models.Sale;
using FarmerApp.Core.Models.User;

namespace FarmerApp.Core.Models.Customer
{
    public class CustomerModel : BaseModel, IHasUserModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string AccountNumber { get; set; }
        public string HVHH { get; set; }

        public int? UserId { get; set; }
        public UserModel User { get; set; }

        public IEnumerable<SaleModel> Sales { get; set; }
    }
}
