using FarmerApp.Core.Models.Interfaces;
using FarmerApp.Core.Models.User;

namespace FarmerApp.Core.Models.MeasurementUnit
{
    public class MeasurementUnitModel : BaseModel, IHasUserModel
    {
        public string Name { get; set; }

        public int? UserId { get; set; }
        public UserModel User { get; set; }
    }
}
