using AutoMapper;
using FarmerApp.Core.Models.MeasurementUnit;
using FarmerApp.Core.Services.Common;
using FarmerApp.Data.Entities;
using FarmerApp.Data.UnitOfWork;

namespace FarmerApp.Core.Services.MeasurementUnit
{
    internal class MeasurementUnitSerivce : BaseService<MeasurementUnitModel, MeasurementUnitEntity>, IMeasurementUnitService
    {
        public MeasurementUnitSerivce(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {            
        }
    }
}
