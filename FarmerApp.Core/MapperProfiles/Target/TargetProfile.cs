using FarmerApp.Core.MapperProfiles.Common;
using FarmerApp.Core.Models.Target;
using FarmerApp.Data.Entities;

namespace FarmerApp.Core.MapperProfiles.Target
{
    public class TargetProfile : BaseProfile<TargetEntity>
    {
        public TargetProfile()
        {
            CreateMap<TargetModel, TargetEntity>().ReverseMap();
            CreateMap<TargetEntity, TargetEntity>()
                .ForMember(d => d.User, opts => opts.Ignore())
                .ForMember(d => d.Expenses, opts => opts.Ignore());
        }
    }
}
