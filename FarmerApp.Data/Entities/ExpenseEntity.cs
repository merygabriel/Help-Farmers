using FarmerApp.Data.Entities.Base;
using FarmerApp.Data.Entities.Interfaces;

namespace FarmerApp.Data.Entities
{
	public class ExpenseEntity : BaseEntity, IHasUser
    {
		public string Name { get; set; }
		public int Amount { get; set; }
        public DateTime? Date { get; set; }

        public int TargetId { get; set; }
        public TargetEntity Target { get; set; }

        public int InvestorId { get; set; }
        public InvestorEntity Investor { get; set; }

        public int? UserId { get; set; }
		public UserEntity User { get; set; }
	}
}

