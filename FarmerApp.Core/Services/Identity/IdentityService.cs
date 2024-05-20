using FarmerApp.Core.Models.Identity;
using FarmerApp.Core.Utils;
using FarmerApp.Data.Entities;
using FarmerApp.Data.Specifications.User;
using FarmerApp.Data.UnitOfWork;
using FarmerApp.Shared.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FarmerApp.Core.Services.Identity
{
    internal class IdentityService : IIdentityService
    {
        const string IdClaimName = "NameIdentifier";

        readonly int accessExpiryMinutes;
        readonly int refreshExpiryMinutes;
        readonly string clientSecretKey;
        readonly string clientSecretKeyForRefresh;

        private readonly IUnitOfWork _uow;
        private readonly ApplicationSettings _settings;

        public IdentityService(IUnitOfWork unitOfWork, ApplicationSettings settings)
        {
            _uow = unitOfWork;
            _settings = settings;

            clientSecretKey = _settings.JwtSecretKey;
            clientSecretKeyForRefresh = _settings.JwtRefreshSecretKey;
            accessExpiryMinutes = _settings.AccessTokenExpiryMinutes;
            refreshExpiryMinutes = _settings.RefreshTokenExpiryMinutes;
        }

        public async Task<AuthenticationResponse> Login(LoginRequest loginRequest)
        {
            var user = await _uow.Repository<UserEntity>().GetFirstBySpecification(new UserByEmailSpecification(loginRequest.UserName));

            if (user == null)
                throw new BadRequestException("Invalid credentials");

            var verificationResult = new PasswordHasher<UserEntity>().VerifyHashedPassword(user, user.Password, loginRequest.Password);
            if (verificationResult != PasswordVerificationResult.Success)
                throw new BadRequestException("Invalid credentials");

            var accessToken = GenerateJwtToken(user, clientSecretKey, accessExpiryMinutes);
            var refreshToken = GenerateJwtToken(user, clientSecretKeyForRefresh, refreshExpiryMinutes);

            user.RefreshToken = refreshToken;
            _uow.Repository<UserEntity>().Update(user);
            await _uow.SaveChangesAsync();

            return new AuthenticationResponse
            {
                Name = user.Name,
                Username = user.Email,
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        public async Task Logout(int userId)
        {
            var user = await _uow.Repository<UserEntity>().GetById(userId);
            if (user == null)
                throw new BadRequestException("No user was found");

            if (user.RefreshToken == default)
                throw new BadRequestException("User is not logged in");

            user.RefreshToken = default;
            _uow.Repository<UserEntity>().Update(user);
            await _uow.SaveChangesAsync();
        }

        public async Task ChangePassword(int userId, ChangePasswordRequest changePasswordRequest)
        {
            var user = await _uow.Repository<UserEntity>().GetById(userId);
            if (user == null)
                throw new BadRequestException("No user was found");

            var passwordHasher = new PasswordHasher<UserEntity>();

            var oldPasswordVerificationResult = passwordHasher.VerifyHashedPassword(user, user.Password, changePasswordRequest.OldPassword);
            if (oldPasswordVerificationResult != PasswordVerificationResult.Success)
                throw new BadRequestException("Invalid old password");

            user.Password = passwordHasher.HashPassword(user, changePasswordRequest.NewPassword);
            _uow.Repository<UserEntity>().Update(user);
            await _uow.SaveChangesAsync();
        }

        public async Task<AuthenticationResponse> Refresh(RefreshTokenRequest refreshTokenRequest)
        {
            var claimsPrincipal = GetClaimsPrincipalFromJwtToken(refreshTokenRequest.RefreshToken, clientSecretKeyForRefresh);

            var user = await _uow.Repository<UserEntity>().GetById(int.Parse(claimsPrincipal.Claims.FirstOrDefault(x => x.Type == IdClaimName).Value));

            if (user == null)
                throw new BadRequestException("Could not get user from access token");

            if (refreshTokenRequest.RefreshToken != user.RefreshToken)
                throw new BadRequestException("Invalid refresh token");

            if (IsTokenExpired(refreshTokenRequest.RefreshToken))
            {
                user.RefreshToken = null;
                _uow.Repository<UserEntity>().Update(user);
                await _uow.SaveChangesAsync();

                throw new BadRequestException("Invalid refresh token");
            }

            var refreshToken = GenerateJwtToken(user, clientSecretKeyForRefresh, refreshExpiryMinutes);
            user.RefreshToken = refreshToken;
            _uow.Repository<UserEntity>().Update(user);
            await _uow.SaveChangesAsync();

            return new AuthenticationResponse
            {
                Name = user.Name,
                Username = user.Email,
                AccessToken = GenerateJwtToken(user, clientSecretKey, accessExpiryMinutes),
                RefreshToken = refreshToken
            };
        }

        private static string GenerateJwtToken(UserEntity user, string secretKey, int expiryMinutes)
        {
            // Create claims for the token
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Name, user.Email),
                new Claim(IdClaimName, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, "example_user"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
            };

            // Create the signing credentials using the secret key
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            // Create the token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(expiryMinutes),
                SigningCredentials = signingCredentials
            };

            // Create the token handler
            var tokenHandler = new JwtSecurityTokenHandler();

            // Generate the token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // Serialize the token to a string
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

        private static ClaimsPrincipal GetClaimsPrincipalFromJwtToken(string jwtToken, string secretKey)
        {
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false, // Set to true if you want to validate the issuer
                ValidateAudience = false, // Set to true if you want to validate the audience
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            // Read the token and parse its claims
            ClaimsPrincipal claimsPrincipal;
            try
            {
                claimsPrincipal = tokenHandler.ValidateToken(jwtToken, validationParameters, out var validatedToken);
            }
            catch (Exception)
            {
                throw new BadRequestException("Invalid token");
            }

            return claimsPrincipal;
        }

        private static bool IsTokenExpired(string jwtToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.ReadToken(jwtToken) as JwtSecurityToken;

            if (jwtSecurityToken == null || jwtSecurityToken.ValidTo == default)
            {
                // Invalid token or missing expiration claim
                return true;
            }

            var expirationDateTime = jwtSecurityToken.ValidTo;
            var currentDateTime = DateTime.UtcNow;

            return currentDateTime > expirationDateTime;
        }
    }
}