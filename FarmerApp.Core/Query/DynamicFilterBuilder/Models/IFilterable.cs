namespace FarmerApp.Core.Query;

public interface IFilterable
{
    List<FilteringItem> AndFilters { get; set; }
    List<FilteringItem> OrFilters { get; set; }
}