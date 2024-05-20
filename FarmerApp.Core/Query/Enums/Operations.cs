namespace FarmerApp.Core.Query.Enums;

public static class Operations
{
    public const string EqualTo = "equalTo";
    public const string NotEqual = "notEqualTo";

    public const string Like = "like";

    public const string GreaterThan = "gt";
    public const string GreaterThanOrEqualTo = "gte";

    public const string LessThan = "lt";
    public const string LessThanOrEqualTo = "lte";

    public const string In = "in";
    public const string NotIn = "notIn";


    public const string NullOrEmpty = "nullOrEmpty";
    public const string NotNullOrEmpty = "notNullOrEmpty";
}