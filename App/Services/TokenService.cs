using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GF.ControleAcesso.Domain.Entities;
using GF.ControleAcesso.Domain.Enums;
using GF.ControleAcesso.Infra.CrossCutting.Helpers;
using Microsoft.IdentityModel.Tokens;

namespace GF.ControleAcesso.App.Services;

public static class TokenService
{
    public static string GerarToken(Usuario user)
    {
        //Estancia do manipulador de Token
        var tokenHandler = new JwtSecurityTokenHandler();
        //Chave da classe Configuration. O Token Handler espera um Array de Bytes, por isso é necessário converter
        var key = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("JWT_CONTROLE_ACESSO_KEY"));
        //
        var claims = new List<Claim>
        {
            new (ClaimTypes.Name, user.Nome),
            new (ClaimTypes.Email, user.Email),
            new (ClaimTypes.Role, ((EPerfil)user.IdPerfil).GetEnumDescription()),
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims), //Claims que vão compor o token
            Expires = DateTime.UtcNow.AddHours(12), //Por quanto tempo vai valer o token?
            SigningCredentials = //Assinatura do token, serve para identificar que mandou o token e garantir que o token não foi alterado no meio do caminho.
            new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        //Gerando o token
        var token = tokenHandler.CreateToken(tokenDescriptor);
        //Retornando tudo como uma string
        return tokenHandler.WriteToken(token);
    }
}
