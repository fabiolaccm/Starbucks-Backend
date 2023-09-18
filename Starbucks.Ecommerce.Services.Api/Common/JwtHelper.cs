using Microsoft.IdentityModel.Tokens;
using Starbucks.Ecommerce.Application.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Starbucks.Ecommerce.Services.Api.Common
{
    public class JwtHelper
    {
        private static string secret = "clave_secreta_para_generacion_token";
        public static string BuildJwt(UserResponseDto user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("username", user.Email),
                    new Claim("id", user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.Name),
                    new Claim(ClaimTypes.Role, "userActive")
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
