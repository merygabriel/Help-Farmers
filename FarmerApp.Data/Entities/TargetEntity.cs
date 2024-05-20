using FarmerApp.Data.Entities.Base;
using FarmerApp.Data.Entities.Interfaces;

namespace FarmerApp.Data.Entities
{
    public class TargetEntity : BaseEntity, IHasUser
    {
        public string Name { get; set; }

        public int? UserId { get; set; }
        public UserEntity User { get; set; }

        public List<ExpenseEntity> Expenses { get; set; }
    }
}
