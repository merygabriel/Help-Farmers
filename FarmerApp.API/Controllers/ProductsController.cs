using AutoMapper;
using FarmerApp.API.Controllers;
using FarmerApp.API.Models.ViewModels.ResponseModels.Product;
using FarmerApp.Core.Models.Product;
using FarmerApp.Core.Services.Product;
using FarmerApp.Data.Entities;
using FarmerApp.Models.ViewModels.RequestModels;

namespace FarmerApp.Controllers
{
    public class ProductsController : BaseController<ProductEntity, ProductModel, ProductResponseModel, ProductRequestModel, ProductRequestModel>
    {
        public ProductsController(IMapper mapper, IProductService productService)
           : base(productService, mapper)
        {
        }
    }
}