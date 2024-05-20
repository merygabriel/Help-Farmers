using AutoMapper;
using FarmerApp.API.Models.ViewModels.ResponseModels.Treatment;
using FarmerApp.Core.Models.Treatment;
using FarmerApp.Models.ViewModels.RequestModels;

namespace FarmerApp.MapperProfiles
{
    public class TreatmentProfile : Profile
    {
        public TreatmentProfile()
        {
            CreateMap<TreatmentRequestModel, TreatmentModel>();
            CreateMap<TreatmentModel, TreatmentResponseModel>();
        }
    }
}