using FarmerApp.API.Models.ViewModels.ResponseModels.Customer;
using FarmerApp.API.Models.ViewModels.ResponseModels.Product;

namespace FarmerApp.API.Models.ViewModels.ResponseModels.Sale
{
    public class SaleResponseModel
    {
        public int Id { get; set; }
        public double Weight { get; set; }
        public int PriceKG { get; set; }
        public int Paid { get; set; }
        public DateTime? Date { get; set; }

        public double Cost { get; set; }
        public double Credit { get; set; }

        public ProductWithNoDepsResponseModel Product { get; set; }
        public CustomerWithNoDepsResponseModel Customer { get; set; }
    }
}

