using FarmerApp.Data.Entities.Interfaces;

namespace FarmerApp.Data.Specifications.Common
{
    public class EntityByUserIdSpecification<TEntity> : BaseSpecification<TEntity>
        where TEntity : IHasUser
    {
        public EntityByUserIdSpecification(int userId) : base(x => x.UserId == userId)
        {            
        }
    }
}
