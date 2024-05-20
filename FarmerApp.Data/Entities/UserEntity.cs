using FarmerApp.Data.Entities.Base;

namespace FarmerApp.Data.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }

        public IEnumerable<ProductEntity> Products { get; set; }
        public IEnumerable<CustomerEntity> Customers { get; set; }
        public IEnumerable<ExpenseEntity> Expenses { get; set; }
        public IEnumerable<InvestorEntity> Investors { get; set; }
        public IEnumerable<SaleEntity> Sales { get; set; }
        public IEnumerable<TreatmentEntity> Treatments { get; set; }
    }
}
