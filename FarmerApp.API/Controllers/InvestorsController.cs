using AutoMapper;
using FarmerApp.API.Controllers;
using FarmerApp.API.Models.ViewModels.ResponseModels.Investment;
using FarmerApp.Core.Models.Investment;
using FarmerApp.Core.Services.Investment;
using FarmerApp.Data.Entities;
using FarmerApp.Models.ViewModels.RequestModels;

namespace FarmerApp.Controllers
{
    public class InvestorsController : BaseController<InvestorEntity, InvestorModel, InvestorResponseModel, InvestorRequestModel, InvestorRequestModel>
    {
        public InvestorsController(IMapper mapper, IInvestorService investorService)
           : base(investorService, mapper, 3)
        {
        }
    }
}