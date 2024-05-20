using AutoMapper;
using FarmerApp.Core.Models.Sale;
using FarmerApp.Core.Services.Common;
using FarmerApp.Data.Entities;
using FarmerApp.Data.UnitOfWork;

namespace FarmerApp.Core.Services.Sale
{
    internal class SaleService : BaseService<SaleModel, SaleEntity>, ISaleService
    {
        public SaleService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<double> GetSumOfAllAmounts()
        {
            return await _uow.Repository<SaleEntity>().Sum(x => x.Paid);
        }
    }
}