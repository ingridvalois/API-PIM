using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API_PIM.Domain.Models;
using Microsoft.IdentityModel.Tokens;

namespace API_PIM.Application.Services
{
    public class TokenServices
    {
        private readonly IConfiguration _configuration;

        public TokenServices(IConfiguration configuration) => _configuration = configuration;

        public object GenerateToken(Usuario usuario)
        {
            byte[] key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Token:Key")!);
            SecurityTokenDescriptor tokenConfig = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim("pessoa", usuario.IdPessoa.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenConfig);

            return new
            {
                token = tokenHandler.WriteToken(token)
            };
        }
    }
}