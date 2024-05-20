namespace FarmerApp.Data.Specifications.Expense
{
    public class ExpenseByIdWithDepsSpecification : ExpensesWithDepsSpecification
    {
        public ExpenseByIdWithDepsSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}
