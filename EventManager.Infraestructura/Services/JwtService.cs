namespace EventManager.Infraestructura.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using EventManager.Dominio.Services;
using EventManager.Dominio.Entities;


public class JwtService : IJwtService
{
    private readonly IConfiguration _configuration; 

    public JwtService(IConfiguration config)
    {
        _configuration = config;
    }
    public string GenerateToken(DJ dj)
    {
         // Paso 1 - Clave secreta
      var key = new SymmetricSecurityKey(
          Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

    // Paso 2 - Credenciales de firma
      var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    // Paso 3 - Claims
      var claims = new[]
      {
          new Claim(ClaimTypes.NameIdentifier, dj.Id.ToString()),
          new Claim(ClaimTypes.Name, dj.User.Username)
      };

    // Paso 4 - Token
      var token = new JwtSecurityToken(
          issuer: _configuration["Jwt:Issuer"],
          audience: _configuration["Jwt:Issuer"],
          claims: claims,
          expires: DateTime.UtcNow.AddHours(2),
          signingCredentials: credentials
    );

    // Paso 5 - Convertir a string
      return new JwtSecurityTokenHandler().WriteToken(token);
    }
}