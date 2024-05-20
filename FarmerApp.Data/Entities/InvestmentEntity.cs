using FarmerApp.Data.Entities.Base;
using FarmerApp.Data.Entities.Interfaces;

namespace FarmerApp.Data.Entities
{
    public class InvestmentEntity : BaseEntity, IHasUser
    {
        public double Amount { get; set; }
        public DateTime Date { get; set; }

        public int InvestorId { get; set; }
        public InvestorEntity Investor { get; set; }

        public int? UserId { get; set; }
        public UserEntity User { get; set; }
    }
}
