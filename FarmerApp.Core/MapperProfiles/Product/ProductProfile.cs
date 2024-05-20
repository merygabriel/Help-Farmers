using FarmerApp.Core.MapperProfiles.Common;
using FarmerApp.Core.Models.Product;
using FarmerApp.Data.Entities;

namespace FarmerApp.Core.MapperProfiles.Product
{
    public class ProductProfile : BaseProfile<ProductEntity>
    {
        public ProductProfile()
        {
            CreateMap<ProductModel, ProductEntity>().ReverseMap();
            CreateMap<ProductEntity, ProductEntity>()
                .ForMember(d => d.User, opts => opts.Ignore())
                .ForMember(d => d.Treatments, opts => opts.Ignore())
                .ForMember(d => d.Sales, opts => opts.Ignore());
        }
    }
}

