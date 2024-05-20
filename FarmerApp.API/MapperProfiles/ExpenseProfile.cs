using AutoMapper;
using FarmerApp.API.Models.ViewModels.ResponseModels.Expense;
using FarmerApp.Core.Models.Expense;
using FarmerApp.Models.ViewModels.RequestModels;

namespace FarmerApp.MapperProfiles
{
    public class ExpenseProfile : Profile
    {
        public ExpenseProfile()
        {
            CreateMap<ExpenseRequestModel, ExpenseModel>();
            CreateMap<ExpenseModel, ExpenseResponseModel>();
        }
    }
}