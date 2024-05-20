using AutoMapper;
using FarmerApp.Core.Models.Investment;
using FarmerApp.Core.Services.Common;
using FarmerApp.Data.Entities;
using FarmerApp.Data.Specifications.Expense;
using FarmerApp.Data.Specifications.Investment;
using FarmerApp.Data.UnitOfWork;

namespace FarmerApp.Core.Services.Investment
{
    internal class InvestorService : BaseService<InvestorModel, InvestorEntity>, IInvestorService
    {
        public InvestorService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public override async Task<InvestorModel> GetById(int id, bool includeDeleted = false, int depth = 1, IEnumerable<string> propertyTypesToExclude = null)
        {
            var entity = await GetEntityById(id, includeDeleted, depth, propertyTypesToExclude);

            var model = _mapper.Map<InvestorModel>(entity);

            model.TotalAmountOfInvestments = await GetTotalAmountOfInvestments(entity);
            model.TotalAmountOfExpenses = await GetTotalAmountOfExpenses(entity);

            return model;
        }

        private async ValueTask<double> GetTotalAmountOfInvestments(InvestorEntity investor)
        {
            var investments = investor.Investments;
            if (investments is null)
            {
                investments = await _uow.Repository<InvestmentEntity>().GetAllBySpecification(new InvestmentsByInvestorIdSpecification(investor.Id));
            }

            return investments.Aggregate(0.0, (total, investment) => total + investment.Amount);
        }

        private async ValueTask<double> GetTotalAmountOfExpenses(InvestorEntity investor)
        {
            var expenses = investor.Expenses;
            if (expenses is null)
            {
                expenses = await _uow.Repository<ExpenseEntity>().GetAllBySpecification(new ExpensesByInvestorIdSpecification(investor.Id));
            }

            return expenses.Aggregate(0.0, (total, expense) => total + expense.Amount);
        }
    }
}