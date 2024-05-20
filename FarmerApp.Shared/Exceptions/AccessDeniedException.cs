namespace FarmerApp.Shared.Exceptions
{
    public class AccessDeniedException : Exception
    {
        public const string DefaultMessage = "Access denied";

        public AccessDeniedException(string message = DefaultMessage) : base(message)
        {
        }
    }
}
