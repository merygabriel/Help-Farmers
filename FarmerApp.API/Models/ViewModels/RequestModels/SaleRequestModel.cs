namespace FarmerApp.Models.ViewModels.RequestModels
{
    public class SaleRequestModel
    {
		public int ProductId { get; set; }
		public double Weight { get; set; }
		public int PriceKG { get; set; }
		public int CustomerId { get; set; }
		public int Paid { get; set; }
        public DateTime? Date { get; set; }
    }
}