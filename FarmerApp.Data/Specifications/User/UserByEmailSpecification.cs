using FarmerApp.Data.Entities;
using FarmerApp.Data.Specifications.Common;

namespace FarmerApp.Data.Specifications.User
{
    public class UserByEmailSpecification : BaseSpecification<UserEntity>
    {
        public UserByEmailSpecification(string email) : base(x => x.Email == email)
        {            
        }
    }
}
