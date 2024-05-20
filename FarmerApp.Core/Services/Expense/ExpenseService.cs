using AutoMapper;
using FarmerApp.Core.Models.Expense;
using FarmerApp.Core.Query;
using FarmerApp.Core.Services.Common;
using FarmerApp.Core.Wrappers;
using FarmerApp.Data.Entities;
using FarmerApp.Data.Entities.Base;
using FarmerApp.Data.Specifications.Common;
using FarmerApp.Data.UnitOfWork;

namespace FarmerApp.Core.Services.Expense
{
    internal class ExpenseService : BaseService<ExpenseModel, ExpenseEntity>, IExpenseService
    {
        public ExpenseService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<PagedExpensesResult<ExpenseModel>> GetAllWithTotalAmount(ISpecification<ExpenseEntity> specification = null, BaseQueryModel query = null, bool includeDeleted = false, int depth = 1, IEnumerable<string> propertyTypesToExclude = null)
        {
            specification ??= new EmptySpecification<ExpenseEntity>();

            int? total = null;

            if (query is not null)
            {
                FilterResults(specification, query);

                total = await _uow.Repository<ExpenseEntity>().Count(specification, includeDeleted);

                IncludeDependenciesByDepth(specification, depth, propertyTypesToExclude);
                OrderResults(specification, query.Orderings);
                ApplyPaging(specification, query);
            }

            var entities = await _uow.Repository<ExpenseEntity>().GetAllBySpecification(specification, includeDeleted);
            var totalAmount = await _uow.Repository<ExpenseEntity>().Sum(x => x.Amount);

            return new PagedExpensesResult<ExpenseModel>
            {
                Results = _mapper.Map<List<ExpenseModel>>(entities),
                Total = total ?? entities.Count,
                PageNumber = query?.PageNumber ?? 1,
                PageSize = query?.PageSize ?? (total ?? entities.Count),
                TotalExpensesAmount = totalAmount
            };
        }
    }
}