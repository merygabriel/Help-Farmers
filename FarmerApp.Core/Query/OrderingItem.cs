namespace FarmerApp.Core.Query;

public class OrderingItem
{
    public string Property { get; set; } = null!;

    public bool IsAscending { get; set; }
}