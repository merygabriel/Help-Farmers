using AutoMapper;
using FarmerApp.API.Controllers;
using FarmerApp.API.Models.ViewModels.ResponseModels.Expense;
using FarmerApp.Core.Models.Expense;
using FarmerApp.Core.Query;
using FarmerApp.Core.Services.Expense;
using FarmerApp.Core.Wrappers;
using FarmerApp.Data.Entities;
using FarmerApp.Data.Specifications.Common;
using FarmerApp.Models.ViewModels.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace FarmerApp.Controllers
{
    public class ExpensesController : BaseController<ExpenseEntity, ExpenseModel, ExpenseResponseModel, ExpenseRequestModel, ExpenseRequestModel>
    {
        public ExpensesController(IMapper mapper, IExpenseService expenseService)
           : base(expenseService, mapper)
        {
        }

        [NonAction]
        public override Task<ActionResult<PagedResult<ExpenseResponseModel>>> Read([FromBody] BaseQueryModel query)
        {
            return base.Read(query);
        }

        [HttpPost("Get")]
        public async Task<ActionResult<PagedExpensesResult<ExpenseResponseModel>>> ReadOverride([FromBody] BaseQueryModel query)
        {
            var data = await ((IExpenseService)_service).GetAllWithTotalAmount(
                new EntityByUserIdSpecification<ExpenseEntity>(UserId), 
                query, 
                false, 
                _depth, 
                _propertyTypesToExclude);

            return Ok(_mapper.Map<PagedExpensesResult<ExpenseResponseModel>>(data));
        }
    }
}