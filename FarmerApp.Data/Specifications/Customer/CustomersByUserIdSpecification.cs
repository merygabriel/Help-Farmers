using FarmerApp.Data.Entities;
using FarmerApp.Data.Specifications.Common;

namespace FarmerApp.Data.Specifications.Customer
{
    public class CustomersByUserIdSpecification : BaseSpecification<CustomerEntity>
    {
        public CustomersByUserIdSpecification(int userId) : base (x => x.UserId == userId)
        {
        }
    }
}
