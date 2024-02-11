using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using Sm.Crm.Application.DTOs.Users;
using Sm.Crm.Application.Tokens;
using Sm.Crm.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Sm.Crm.Infrastructure.Tokens
{
    public class TokenHandler : ITokenHandler
    {
        readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Token CreateAccessToken(int second, User user)
        {
            Token token = new();
            
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
                 
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);
           
            token.Expiration = DateTime.UtcNow.AddSeconds(second);
            JwtSecurityToken securityToken = new(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: token.Expiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials,          
                claims: new List<Claim> { new(ClaimTypes.Name, user.UserName) }
                );
          
            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(securityToken);
            

            token.RefreshToken = CreateRefreshToken();
            return token;
        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(number);
            return Convert.ToBase64String(number);
        }
    }
}
