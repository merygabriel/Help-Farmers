using FarmerApp.Core.MapperProfiles.Common;
using FarmerApp.Core.Models.Customer;
using FarmerApp.Data.Entities;

namespace FarmerApp.Core.MapperProfiles.Customer
{
    public class CustomerProfile : BaseProfile<CustomerEntity>
    {
        public CustomerProfile()
        {
            CreateMap<CustomerModel, CustomerEntity>().ReverseMap();
            CreateMap<CustomerEntity, CustomerEntity>()
                .ForMember(d => d.User, opts => opts.Ignore())
                .ForMember(d => d.Sales, opts => opts.Ignore());
        }
    }
}
