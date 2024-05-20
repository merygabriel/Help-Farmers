using AutoMapper;
using FarmerApp.API.Models.ViewModels.ResponseModels.Customer;
using FarmerApp.Core.Models.Customer;
using FarmerApp.Models.ViewModels.RequestModels;

namespace FarmerApp.MapperProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerModel, CustomerResponseModel>();
            CreateMap<CustomerModel, CustomerWithNoDepsResponseModel>();
            CreateMap<CustomerRequestModel, CustomerModel>();
        }
    }
}