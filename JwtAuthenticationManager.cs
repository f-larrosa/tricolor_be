using Tricolor_BE.Entities;
using Tricolor_BE.Services;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Tricolor_BE
{
    public class JwtAuthenticationManager
    {
        private readonly string jwtKey;
        public JwtAuthenticationManager(string jwtKey)
        {
            this.jwtKey = jwtKey;
        }

        public string? Authenticate(Usuario usuario)
        {
            AccountService accountService = new();
            if (!accountService.Authenticate(usuario))
                return null;

            JwtSecurityTokenHandler tokenHandler = new();
            var tokenKey = Encoding.ASCII.GetBytes(jwtKey);

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Email)
                }),

                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
