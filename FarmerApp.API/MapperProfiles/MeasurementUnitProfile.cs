using AutoMapper;
using FarmerApp.API.Models.ViewModels.RequestModels;
using FarmerApp.API.Models.ViewModels.ResponseModels.MeasurementUnit;
using FarmerApp.Core.Models.MeasurementUnit;

namespace FarmerApp.API.MapperProfiles
{
    public class MeasurementUnitProfile : Profile
    {
        public MeasurementUnitProfile()
        {
            CreateMap<MeasurementUnitModel, MeasurementUnitResponseModel>();
            CreateMap<MeasurementUnitRequestModel, MeasurementUnitModel>();
        }
    }
}
