using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Loja.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Loja.Service.Jwt
{
    public class TokenService
    {
        public static string GenerateToken(UserEntity user)
        {   /* Gerando o token com JwtSecurityTokenHandler.CreateToken e informando um 
            SecurityTokenDescriptor. 
            */

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);  /*Pegando o atributo secret coma chave*/
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity( new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),

                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}