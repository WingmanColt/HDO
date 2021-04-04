using Core.Helpers;
using Data.Repositories.Contracts;
using Microsoft.IdentityModel.Tokens;
using Models;
using Services.Users.Contracts;
using Services.Users.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services.Users
{
    public class AuthService : IAuthService
    {

        private readonly IRepository<User> _userRepository;

        public AuthService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public AuthModel GetAuthData(string id)
        {
            var expirationTime = DateTime.UtcNow.AddSeconds(2592000);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, id)
                }),
                Expires = expirationTime,
                // new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature)
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bRhYJRlZvBj2vW4MrV5HVdPgIE6VMtCFB0kTtJ1m")),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

            return new AuthModel
            {
                Token = token,
                TokenExpirationTime = ((DateTimeOffset)expirationTime).ToUnixTimeSeconds(),
                Id = id
            };
        }


        public bool isEmailUniq(string email)
        {
            var user = _userRepository.GetSingle(u => u.Email == email);
            return user == null;
        }

        public bool IsUsernameUniq(string username)
        {
            var user = _userRepository.GetSingle(u => u.UserName == username);
            return user == null;
        }

        public string HashPassword(string password)
        {
            return CryptoHelper.HashPassword(password);
        }

        public bool VerifyPassword(string actualPassword, string hashedPassword)
        {
            return CryptoHelper.VerifyHashedPassword(hashedPassword, actualPassword);
        }
    }
}
