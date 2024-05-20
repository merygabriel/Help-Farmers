using System.ComponentModel.DataAnnotations;

namespace FarmerApp.Data.Entities.Base
{
    public abstract class BaseEntity : DbEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public bool IsDeleted { get; set; } = false;

        [Timestamp]
        public byte[] Version { get; set; }
    }
}
