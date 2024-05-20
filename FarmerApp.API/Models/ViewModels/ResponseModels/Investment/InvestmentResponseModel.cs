namespace FarmerApp.API.Models.ViewModels.ResponseModels.Investment
{
    public class InvestmentResponseModel
    {
        public int Id { get; set; }

        public double Amount { get; set; }
        public DateTime Date { get; set; }

        public int InvestorId { get; set; }
        public InvestorResponseModel Investor { get; set; }
    }
}
