using FarmerApp.Core.MapperProfiles.Common;
using FarmerApp.Core.Models.MeasurementUnit;
using FarmerApp.Data.Entities;

namespace FarmerApp.Core.MapperProfiles.MeasurementUnit
{
    public class MeasurementUnitProfile : BaseProfile<MeasurementUnitEntity>
    {
        public MeasurementUnitProfile()
        {
            CreateMap<MeasurementUnitModel, MeasurementUnitEntity>().ReverseMap();
            CreateMap<MeasurementUnitEntity, MeasurementUnitEntity>()
                .ForMember(d => d.User, opts => opts.Ignore());
        }
    }
}
