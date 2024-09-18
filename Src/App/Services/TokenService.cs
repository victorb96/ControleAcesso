using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GF.ControleAcesso.Domain.Entities;
using GF.ControleAcesso.Domain.Enums;
using Microsoft.IdentityModel.Tokens;
using GF.ControleAcesso.Domain.Helpers;

namespace GF.ControleAcesso.App.Services;

public static class TokenService
{
    public static string GerarToken(Usuario user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("JWT_CONTROLE_ACESSO_KEY"));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new List<Claim>
            {
                new (ClaimTypes.Name, user.Nome),
                new (ClaimTypes.Email, user.Email),
                new (ClaimTypes.Role, ((EPerfil)user.IdPerfil).GetEnumDescription()),
            }),
            Expires = DateTime.UtcNow.AddHours(12),
            SigningCredentials =
            new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
