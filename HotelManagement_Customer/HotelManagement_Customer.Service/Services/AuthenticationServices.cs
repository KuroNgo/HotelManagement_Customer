using HotelManagement_Customer.Model.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using System.Linq;
using System.Security.Cryptography;

namespace HotelManagement_Customer.Service
{
    public interface IAuthenticationService
    {
        AuthenticationResult Login(string loginName, string password);
        AuthenticationResult RefreshToken(string token);
    }

    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserServices _userServices;
        private readonly string _jwtSecret;
        private readonly int _jwtExpirationMinutes;
        private readonly string _refreshTokenSecret;
        private readonly int _refreshTokenExpirationDays;

        public AuthenticationService(
            IUserServices userServices,
            string jwtSecret,
            int jwtExpirationMinutes,
            string refreshTokenSecret,
            int refreshTokenExpirationDays)
        {
            _userServices = userServices;
            _jwtSecret = jwtSecret;
            _jwtExpirationMinutes = jwtExpirationMinutes;
            _refreshTokenSecret = refreshTokenSecret;
            _refreshTokenExpirationDays = refreshTokenExpirationDays;
        }

        public AuthenticationResult Login(string loginName, string password)
        {
            var user = _userServices.GetByLoginName(loginName);

            if (user == null)
            {
                throw new Exception("Invalid login credentials.");
            }

            // Verify the hashed password
            if (!VerifyPasswordHash(password, user.Password))
            {
                throw new Exception("Invalid login credentials.");
            }

            // Authentication successful, generate JWT token and refresh token
            var jwtToken = GenerateJwtToken(user);
            var refreshToken = GenerateRefreshToken();

            // Save the refresh token to the user entity
            user.RefreshToken = refreshToken;
            _userServices.SaveChanges();

            return new AuthenticationResult
            {
                JwtToken = jwtToken,
                RefreshToken = refreshToken
            };
        }

        public AuthenticationResult RefreshToken(string token)
        {
            var validatedToken = GetPrincipalFromToken(token);
            if (validatedToken == null)
            {
                throw new Exception("Invalid token.");
            }

            var userId = int.Parse(validatedToken.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value);
            var user = _userServices.GetById(userId);

            if (user == null || user.RefreshToken != token || !IsRefreshTokenValid(user.RefreshToken))
            {
                throw new Exception("Invalid token.");
            }

            // Generate a new JWT token and refresh token
            var jwtToken = GenerateJwtToken(user);
            var refreshToken = GenerateRefreshToken();

            // Update the refresh token in the user entity
            user.RefreshToken = refreshToken;
            _userServices.SaveChanges();

            return new AuthenticationResult
            {
                JwtToken = jwtToken,
                RefreshToken = refreshToken
            };
        }

        private string GenerateJwtToken(UserAccount user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.LoginName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(_jwtExpirationMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private bool VerifyPasswordHash(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        private ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSecret)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out var validatedToken);

                return principal;
            }
            catch
            {
                return null;
            }
        }

        private bool IsRefreshTokenValid(string token)
        {
            var expiryDate = JwtHelper.GetTokenExpirationDate(token);
            return expiryDate > DateTime.UtcNow;
        }
    }

    public class AuthenticationResult
    {
        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }
    }

    public static class JwtHelper
    {
        public static DateTime GetTokenExpirationDate(string token)
        {
            // Your existing code to parse the expiration date from the token and return it
            // Example implementation:
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
            if (jwtToken == null)
                throw new ArgumentException("Invalid JWT token.");

            var expiryDate = jwtToken.ValidTo;
            return expiryDate;
        }
    }
}
