using AutoMapper;
using FarmerApp.Core.Wrappers;

namespace FarmerApp.API.MapperProfiles
{
    public class UtilsProfile : Profile
    {
        public UtilsProfile()
        {
            CreateMap(typeof(PagedResult<>), typeof(PagedResult<>));
            CreateMap(typeof(PagedExpensesResult<>), typeof(PagedExpensesResult<>));
        }
    }
}
