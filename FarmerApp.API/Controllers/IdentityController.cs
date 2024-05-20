using FarmerApp.Core.Models.Identity;
using FarmerApp.Core.Services.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<AuthenticationResponse>> Login(LoginRequest loginRequest)
        {
            var authResponse = await _identityService.Login(loginRequest);

            return Ok(authResponse);
        }

        [HttpPost("Refresh")]
        public async Task<ActionResult<AuthenticationResponse>> Refresh(RefreshTokenRequest refreshTokenRequest)
        {
            var authResponse = await _identityService.Refresh(refreshTokenRequest);

            return Ok(authResponse);
        }

        [Authorize]
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "NameIdentifier").Value);

            await _identityService.Logout(userId);

            return Ok();
        }

        [Authorize]
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequest changePasswordRequest)
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "NameIdentifier").Value);

            await _identityService.ChangePassword(userId, changePasswordRequest);

            return Ok();
        }
    }
}
