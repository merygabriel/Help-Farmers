using FarmerApp.Core.Models.Customer;
using FarmerApp.Core.Services.Common;
using FarmerApp.Data.Entities;

namespace FarmerApp.Core.Services.Customer
{
    public interface ICustomerService : IBaseService<CustomerModel, CustomerEntity>
    {
    }
}
