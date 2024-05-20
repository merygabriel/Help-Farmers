namespace FarmerApp.Core.Query;

public interface IPaging
{
    int PageNumber { get; set; }

    int PageSize { get; set; }
}