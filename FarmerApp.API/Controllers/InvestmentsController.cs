using AutoMapper;
using FarmerApp.API.Controllers;
using FarmerApp.API.Models.ViewModels.ResponseModels.Investment;
using FarmerApp.Core.Models.Investment;
using FarmerApp.Core.Services.Investment;
using FarmerApp.Core.Services.Sale;
using FarmerApp.Data.Entities;
using FarmerApp.Models.ViewModels.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace FarmerApp.Controllers
{
    public class InvestmentsController : BaseController<InvestmentEntity, InvestmentModel, InvestmentResponseModel, InvestmentRequestModel, InvestmentRequestModel>
    {
        private readonly ISaleService _saleService;

        public InvestmentsController(IMapper mapper, IInvestmentService investmentService, ISaleService saleService)
           : base(investmentService, mapper)
        {
            _saleService = saleService;
        }

        [HttpGet("GetSumOfAllSaleAmounts")]
        public async Task<ActionResult<double>> GetSumOfAllSaleAmounts()
        {
            return await _saleService.GetSumOfAllAmounts();
        }
    }
}