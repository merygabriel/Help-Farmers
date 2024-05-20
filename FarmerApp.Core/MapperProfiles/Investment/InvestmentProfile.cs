using FarmerApp.Core.MapperProfiles.Common;
using FarmerApp.Core.Models.Investment;
using FarmerApp.Data.Entities;

namespace FarmerApp.Core.MapperProfiles.Investment
{
    public class InvestmentProfile : BaseProfile<InvestmentEntity>
    {
        public InvestmentProfile()
        {
            CreateMap<InvestmentModel, InvestmentEntity>().ReverseMap();
            CreateMap<InvestmentEntity, InvestmentEntity>()
                .ForMember(d => d.User, opts => opts.Ignore())
                .ForMember(d => d.Investor, opts => opts.Ignore());
        }
    }
}
