using AutoMapper;
using FarmerApp.Core.Models.Customer;
using FarmerApp.Core.Services.Common;
using FarmerApp.Data.Entities;
using FarmerApp.Data.UnitOfWork;

namespace FarmerApp.Core.Services.Customer
{
    internal class CustomerService : BaseService<CustomerModel, CustomerEntity>, ICustomerService
    {
        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}