using AutoMapper;
using FarmerApp.API.Models.ViewModels.ResponseModels.Sale;
using FarmerApp.Core.Models.Sale;
using FarmerApp.Models.ViewModels.RequestModels;

namespace FarmerApp.MapperProfiles
{
    public class SaleProfile : Profile
    {
        public SaleProfile()
        {
            CreateMap<SaleRequestModel, SaleModel>();
            CreateMap<SaleModel, SaleResponseModel>()
                .ForMember(d => d.Credit, opts => opts.MapFrom(s => Math.Abs(s.Credit)));
        }
    }
}