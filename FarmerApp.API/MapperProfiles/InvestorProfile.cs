using AutoMapper;
using FarmerApp.API.Models.ViewModels.ResponseModels.Investment;
using FarmerApp.Core.Models.Investment;
using FarmerApp.Models.ViewModels.RequestModels;

namespace FarmerApp.MapperProfiles
{
    public class InvestorProfile : Profile
    {
        public InvestorProfile()
        {
            CreateMap<InvestorRequestModel, InvestorModel>();           
            CreateMap<InvestorModel, InvestorResponseModel>();
        }
    }
}