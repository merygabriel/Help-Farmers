namespace FarmerApp.Core.Query;

public class BaseQueryModel : IFilterable, IOrderable, IPaging
{
    public List<FilteringItem> AndFilters { get; set; }
    public List<FilteringItem> OrFilters { get; set; }
    public List<OrderingItem> Orderings { get; set; }

    public int PageNumber { get; set; } = 0;
    public int PageSize { get; set; } = 0;
}