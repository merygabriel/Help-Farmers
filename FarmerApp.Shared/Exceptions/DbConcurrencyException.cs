using System.Text.Json;

namespace FarmerApp.Shared.Exceptions
{
    public class DbConcurrencyException : Exception
    {
        private readonly IEnumerable<DbConcurrencyExceptionItem> _items;

        public DbConcurrencyException(IEnumerable<DbConcurrencyExceptionItem> items) : base()
        {
            _items = items;
        }

        public override string Message => JsonSerializer.Serialize(_items);
    }

    public class DbConcurrencyExceptionItem
    {
        public string Entity { get; set; }
        public string Property { get; set; }
        public object ProposedValue { get; set; }
        public object OriginalValue { get; set; }
        public object DatabaseValue { get; set; }
    }
}
