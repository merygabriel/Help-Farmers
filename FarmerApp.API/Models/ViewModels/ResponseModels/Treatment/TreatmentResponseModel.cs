using FarmerApp.API.Models.ViewModels.ResponseModels.MeasurementUnit;
using FarmerApp.API.Models.ViewModels.ResponseModels.Product;

namespace FarmerApp.API.Models.ViewModels.ResponseModels.Treatment
{
    public class TreatmentResponseModel
    {
        public int Id { get; set; }
        public string DrugName { get; set; }
        public double DrugAmount { get; set; }
        public DateTime? Date { get; set; }
        
        public MeasurementUnitResponseModel MeasurementUnit { get; set; }

        public IEnumerable<ProductWithNoDepsResponseModel> Products { get; set; }
    }
}

