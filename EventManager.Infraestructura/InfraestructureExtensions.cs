using Microsoft.Extensions.DependencyInjection;
using EventManager.Dominio.Abstractions.Repositories;
using EventManager.Dominio.Services;
using EventManager.Infraestructura.Repositories;
using Microsoft.EntityFrameworkCore;
using EventManager.Infraestructura.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace EventManager.Infraestructura;

public static class InfraestructureExtensions
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IDJRepository, DJRepository>();
        services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=EventManager.db"));
        services.AddScoped<IJwtService, JwtService>();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
            };
        });

//se declara el servicio y se registra en el contenedor de inyeccion de dependencias
//cuando el repositorio lo necesite, el contenedor se lo inyecta automaticamente
        return services;
    }
}