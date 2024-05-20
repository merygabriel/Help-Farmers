namespace FarmerApp.Core.Models
{
    public class BaseModel
    {
        public int? Id { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
