using APIComBanco.API.Domain.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public static class TokenService
{
    public static string GenerateToken(Usuarios usuario, string secret)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        // A chave deve ser longa e secreta (mova para o appsettings.json depois)
        var key = Encoding.ASCII.GetBytes(secret);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                    new Claim(ClaimTypes.Name, usuario.nome),
                    new Claim(ClaimTypes.Email, usuario.email),
                    new Claim("id", usuario.id.ToString())
                }),
            Expires = DateTime.UtcNow.AddHours(2), // Token expira em 2 horas
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
