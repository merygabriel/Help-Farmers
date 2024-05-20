using FarmerApp.Core.Models.User;

namespace FarmerApp.Core.Models.Interfaces
{
    public interface IHasUserModel
    {
        int? UserId { get; set; }
        UserModel User { get; set; }
    }
}
