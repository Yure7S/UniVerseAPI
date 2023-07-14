using Azure.Core;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Application.IServices;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Application.Services.Utils
{
    public class TokenService : ITokenService
    {

        public readonly IConfiguration _IConfiguration;

        public TokenService(IConfiguration configuration)
        {
            _IConfiguration = configuration;
        }
        public string GenerateToken(UserTokenDTO user)
        {
            JwtSecurityTokenHandler tokenHandler = new();
            byte[] key = Encoding.ASCII.GetBytes(_IConfiguration["JwtProperties:key"]!);
            SecurityTokenDescriptor tockenDrecriptor = new()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt16(_IConfiguration["JwtProperties:AccessTokenValidity"]!)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tockenDrecriptor); 
            return tokenHandler.WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            return "Em desenvolvimento";
        }
        
        public ClaimsPrincipalDTO GetClaimsFromExpiredToken(string token)
        {
            TokenValidationParameters tokenValidationParameters = new()
            {
                ValidateIssuer = false,
                ValidateAudience = false, 
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_IConfiguration["JwtProperties:key"]!)),
            };

            JwtSecurityTokenHandler tokenHandler = new();
            ClaimsPrincipal principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

            if (securityToken is not JwtSecurityToken jwtSecurityToken ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
                return new ClaimsPrincipalDTO
                {
                    Message = "Invalid token",
                    Success = false
                };

            return new ClaimsPrincipalDTO { Claims = principal };
        }
    }
}
