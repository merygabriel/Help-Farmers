namespace FarmerApp.Models.ViewModels.RequestModels
{
    public class ExpenseRequestModel
    {
		public string Name { get; set; }
		public int Amount { get; set; }
        public DateTime? Date { get; set; }

        public int TargetId { get; set; }
        public int InvestorId { get; set; }
    }
}