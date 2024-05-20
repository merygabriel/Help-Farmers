using AutoMapper;
using FarmerApp.API.Models.ViewModels.ResponseModels.Product;
using FarmerApp.Core.Models.Product;
using FarmerApp.Models.ViewModels.RequestModels;

namespace FarmerApp.MapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductRequestModel, ProductModel>();            
            CreateMap<ProductModel, ProductResponseModel>();
            CreateMap<ProductModel, ProductWithNoDepsResponseModel>();
        }
    }
}