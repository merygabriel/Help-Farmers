using AutoMapper;
using FarmerApp.API.Controllers;
using FarmerApp.API.Models.ViewModels.ResponseModels.Target;
using FarmerApp.Core.Models.Target;
using FarmerApp.Core.Services.Target;
using FarmerApp.Data.Entities;
using FarmerApp.Models.ViewModels.RequestModels;

namespace FarmerApp.Controllers
{
    public class TargetsController : BaseController<TargetEntity, TargetModel, TargetResponseModel, TargetRequestModel, TargetRequestModel>
    {
        public TargetsController(IMapper mapper, ITargetService targetService)
           : base(targetService, mapper)
        {
        }
    }
}