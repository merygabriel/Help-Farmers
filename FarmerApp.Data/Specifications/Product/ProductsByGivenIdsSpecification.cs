using FarmerApp.Data.Entities;
using FarmerApp.Data.Specifications.Common;

namespace FarmerApp.Data.Specifications.Product
{
    public class ProductsByGivenIdsSpecification : BaseSpecification<ProductEntity>
    {
        public ProductsByGivenIdsSpecification(IEnumerable<int> ids) : base(x => ids.Contains(x.Id))
        {            
        }
    }
}
