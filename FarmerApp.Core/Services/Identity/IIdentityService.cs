using FarmerApp.Core.Models.Identity;

namespace FarmerApp.Core.Services.Identity
{
    public interface IIdentityService
    {
        Task<AuthenticationResponse> Login(LoginRequest loginRequest);
        Task<AuthenticationResponse> Refresh(RefreshTokenRequest refreshTokenRequest);
        Task Logout(int userId);
        Task ChangePassword(int userId, ChangePasswordRequest changePasswordRequest);
    }
}
