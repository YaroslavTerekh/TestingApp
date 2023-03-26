using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebTesting.BL.Behaviors.Authorization.Register;
using WebTesting.BL.Services.Abstractions;
using WebTesting.Domain.DataTransferObjects;
using WebTesting.Domain.Entities;

namespace WebTesting.BL.Services.Realizations
{
    public class JWTService : IJWTService
    {
        public IConfiguration _configuration;

        public JWTService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TokenDTO GenerateToken(User user, CancellationToken cancellationToken = default)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(type: ClaimTypes.NameIdentifier, value: user.Id.ToString()),
                new Claim(type: ClaimTypes.Email, user.Email),
                new Claim(type: ClaimTypes.Role, user.Role.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.Now.AddDays(1);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: expires,
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return new TokenDTO
            {
                Token = jwt,
                ExpireTime = expires
            };
        }
    }
}
