namespace FarmerApp.Core.Models.Identity
{
    public class AuthenticationResponse
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
