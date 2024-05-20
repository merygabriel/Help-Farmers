namespace FarmerApp.Core.Query;

public class FilteringItem
{
    public string Property { get; set; } = null!;

    public string Operation { get; set; } = null!;

    public string Value { get; set; } = null!;

    public override string ToString()
    {
        return $"{Property} {Operation} {Value}";
    }
}