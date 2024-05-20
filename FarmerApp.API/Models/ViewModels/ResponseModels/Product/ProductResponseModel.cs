using FarmerApp.API.Models.ViewModels.ResponseModels.Sale;

namespace FarmerApp.API.Models.ViewModels.ResponseModels.Product
{
    public class ProductResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PriceKG { get; set; }
        public IEnumerable<SaleResponseModel> Sales { get; set; }
    }
}