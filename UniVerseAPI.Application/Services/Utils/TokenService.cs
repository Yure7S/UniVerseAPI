using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UniVerseAPI.Infra.Data.Context;

namespace UniVerseAPI.Application.Services.Utils
{
    public static class TokenService
    {
        public static string GeneratedToken(UserTokenDTO user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tockenDrecriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature) // Criptografia das informações
            };
            var token = tokenHandler.CreateToken(tockenDrecriptor); // Criando o token se baseando no tockenDrecriptor
            return tokenHandler.WriteToken(token); // Retornando a string do token
        }
    }
}
