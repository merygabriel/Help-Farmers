using FarmerApp.API.Models.ViewModels.ResponseModels.Sale;

namespace FarmerApp.API.Models.ViewModels.ResponseModels.Customer
{
    public class CustomerResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string AccountNumber { get; set; }
        public string HVHH { get; set; }

        public IEnumerable<SaleResponseModel> Sales { get; set; }
    }
}