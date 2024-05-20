using AutoMapper;
using FarmerApp.API.Models.ViewModels.ResponseModels.Investment;
using FarmerApp.Core.Models.Investment;
using FarmerApp.Models.ViewModels.RequestModels;

namespace FarmerApp.MapperProfiles
{
    public class InvestmentProfile : Profile
    {
        public InvestmentProfile()
        {
            CreateMap<InvestmentRequestModel, InvestmentModel>();
            CreateMap<InvestmentModel, InvestmentResponseModel>();
        }
    }
}
