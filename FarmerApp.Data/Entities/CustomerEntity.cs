using FarmerApp.Data.Entities.Base;
using FarmerApp.Data.Entities.Interfaces;

namespace FarmerApp.Data.Entities
{
	public class CustomerEntity : BaseEntity, IHasUser
    {
		public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
		public string AccountNumber { get; set; }
		public string HVHH { get; set; }

        public int? UserId { get; set; }
        public UserEntity User { get; set; }

		public IEnumerable<SaleEntity> Sales { get; set; }
    }
}

