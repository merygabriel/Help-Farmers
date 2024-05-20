using FarmerApp.Core.Models.Expense;
using FarmerApp.Core.Query;
using FarmerApp.Core.Services.Common;
using FarmerApp.Core.Wrappers;
using FarmerApp.Data.Entities;
using FarmerApp.Data.Specifications.Common;

namespace FarmerApp.Core.Services.Expense
{
    public interface IExpenseService : IBaseService<ExpenseModel, ExpenseEntity>
    {
        Task<PagedExpensesResult<ExpenseModel>> GetAllWithTotalAmount(ISpecification<ExpenseEntity> specification = null, BaseQueryModel query = null, bool includeDeleted = false, int depth = 1, IEnumerable<string> propertyTypesToExclude = null);
    }
}
