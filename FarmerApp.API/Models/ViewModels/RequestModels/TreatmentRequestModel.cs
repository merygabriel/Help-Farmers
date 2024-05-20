namespace FarmerApp.Models.ViewModels.RequestModels
{
    public class TreatmentRequestModel
	{
		public string DrugName { get; set; }
		public double DrugAmount { get; set; }
        public DateTime? Date { get; set; }

        public int? MeasurementUnitId { get; set; }

        public int[] TreatedProductsIds { get; set; } 
    }
}