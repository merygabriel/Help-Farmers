using FarmerApp.Models.ViewModels.RequestModels;
using AutoMapper;
using FarmerApp.Core.Models.Target;
using FarmerApp.API.Models.ViewModels.ResponseModels.Target;

namespace FarmerApp.MapperProfiles
{
    public class TargetProfile : Profile
    {
        public TargetProfile()
        {
            CreateMap<TargetRequestModel, TargetModel>();
            CreateMap<TargetModel, TargetResponseModel>();
        }
    }
}
