using FarmerApp.Core.Models.Interfaces;
using FarmerApp.Core.Models.Sale;
using FarmerApp.Core.Models.Treatment;
using FarmerApp.Core.Models.User;

namespace FarmerApp.Core.Models.Product
{
    public class ProductModel : BaseModel, IHasUserModel
    {
        public string Name { get; set; }
        public int PriceKG { get; set; }

        public int? UserId { get; set; }
        public UserModel User { get; set; }

        public IEnumerable<SaleModel> Sales { get; set; }
        public IEnumerable<TreatmentModel> Treatments { get; set; }
    }
}

