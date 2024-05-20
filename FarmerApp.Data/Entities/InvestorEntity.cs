using FarmerApp.Data.Entities.Base;
using FarmerApp.Data.Entities.Interfaces;

namespace FarmerApp.Data.Entities
{
	public class InvestorEntity : BaseEntity, IHasUser
    {
		public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public int? UserId { get; set; }
        public UserEntity User { get; set; }

        public IEnumerable<InvestmentEntity> Investments { get; set; }
        public IEnumerable<ExpenseEntity> Expenses { get; set; }
    }
}

