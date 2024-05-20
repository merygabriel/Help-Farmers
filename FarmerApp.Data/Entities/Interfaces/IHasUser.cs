namespace FarmerApp.Data.Entities.Interfaces
{
    public interface IHasUser
    {
        int? UserId { get; set; }
        UserEntity User { get; set; }
    }
}
