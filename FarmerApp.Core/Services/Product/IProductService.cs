using FarmerApp.Core.Models.Product;
using FarmerApp.Core.Services.Common;
using FarmerApp.Data.Entities;

namespace FarmerApp.Core.Services.Product
{
    public interface IProductService : IBaseService<ProductModel, ProductEntity>
    {
    }
}
