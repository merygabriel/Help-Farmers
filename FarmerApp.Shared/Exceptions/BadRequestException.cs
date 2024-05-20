namespace FarmerApp.Shared.Exceptions
{
    public class BadRequestException : Exception
    {
        public const string DefaultMessage = "Bad request";

        public BadRequestException(string message = DefaultMessage) : base(message)
        {
        }
    }
}
