using FarmerApp.Core.Models.Interfaces;
using FarmerApp.Core.Models.MeasurementUnit;
using FarmerApp.Core.Models.Product;
using FarmerApp.Core.Models.User;

namespace FarmerApp.Core.Models.Treatment
{
    public class TreatmentModel : BaseModel, IHasUserModel
    {
        public string DrugName { get; set; }
        public double DrugAmount { get; set; }
        public DateTime? Date { get; set; }

        public int[] TreatedProductsIds { get; set; }

        public int? MeasurementUnitId { get; set; }
        public MeasurementUnitModel MeasurementUnit { get; set; }

        public int? UserId { get; set; }
        public UserModel User { get; set; }

        public IEnumerable<ProductModel> Products { get; set; }

    }
}