using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BackendUygulama.Models;
using Microsoft.IdentityModel.Tokens;

namespace BackendUygulama;

public class Security
{
    internal static string CreateToken(User user, IConfiguration configuration)
    {
        var issuer = configuration["Jwt:Issuer"];
        var audience = configuration["Jwt:Audience"];
        var key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]!);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("Id", Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.Mail),
                new Claim(JwtRegisteredClaimNames.Email, user.Mail),
                new Claim(JwtRegisteredClaimNames.Jti,
                    Guid.NewGuid().ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials
            (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = tokenHandler.WriteToken(token);
        var stringToken = tokenHandler.WriteToken(token);
        return stringToken;
    }
}