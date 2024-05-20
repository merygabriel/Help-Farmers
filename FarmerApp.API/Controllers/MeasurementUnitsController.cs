using AutoMapper;
using FarmerApp.API.Models.ViewModels.RequestModels;
using FarmerApp.API.Models.ViewModels.ResponseModels.MeasurementUnit;
using FarmerApp.Core.Models.MeasurementUnit;
using FarmerApp.Core.Services.MeasurementUnit;
using FarmerApp.Data.Entities;

namespace FarmerApp.API.Controllers
{
    public class MeasurementUnitsController 
        : BaseController<MeasurementUnitEntity, MeasurementUnitModel, MeasurementUnitResponseModel, 
                        MeasurementUnitRequestModel, MeasurementUnitRequestModel>
    {
        public MeasurementUnitsController(IMapper mapper, IMeasurementUnitService measurementUnitService)
           : base(measurementUnitService, mapper)
        {
        }
    }
}
