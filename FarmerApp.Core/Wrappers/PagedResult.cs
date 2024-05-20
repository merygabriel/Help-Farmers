namespace FarmerApp.Core.Wrappers
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Results { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }

        public int Total { get; set; }
    }

    public class PagedExpensesResult<T> : PagedResult<T>
    {
        public double? TotalExpensesAmount { get; set; }
    }
}
