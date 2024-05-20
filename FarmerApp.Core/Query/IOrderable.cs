namespace FarmerApp.Core.Query;

public interface IOrderable
{
    List<OrderingItem> Orderings { get; set; }
}