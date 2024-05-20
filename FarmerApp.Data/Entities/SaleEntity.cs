using FarmerApp.Data.Entities.Base;
using FarmerApp.Data.Entities.Interfaces;

namespace FarmerApp.Data.Entities
{
	public class SaleEntity : BaseEntity, IHasUser
    {
		public double Weight { get; set; }
		public int PriceKG { get; set; }
		public int Paid { get; set; }
		public DateTime? Date { get; set; }

		public int ProductId { get; set; }
		public ProductEntity Product { get; set; }

		public int CustomerId { get; set; }
		public CustomerEntity Customer { get; set; }

        public int? UserId { get; set; }
        public UserEntity User { get; set; }
    }
}

