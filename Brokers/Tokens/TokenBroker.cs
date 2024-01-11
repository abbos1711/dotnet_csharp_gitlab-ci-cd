using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using dosLogistic.API.Models.Foundations.Tokens;
using dosLogistic.API.Models.Foundations.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace dosLogistic.API.Brokers.Tokens
{
    public class TokenBroker : ITokenBroker
    {
        private readonly TokenConfiguration tokenConfiguration;

        public TokenBroker(IConfiguration configuration)
        {
            this.tokenConfiguration = new TokenConfiguration();
            configuration.Bind("Jwt", this.tokenConfiguration);
        }

        public string GenerateJWT(User user)
        {

            byte[] convertedKeyToBytes =
                Encoding.UTF8.GetBytes(this.tokenConfiguration.Key);

            var securityKey =
                new SymmetricSecurityKey(convertedKeyToBytes);

            var cridentials =
                new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
            };

            var token = new JwtSecurityToken(
                this.tokenConfiguration.Issuer,
                this.tokenConfiguration.Audience,
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cridentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
