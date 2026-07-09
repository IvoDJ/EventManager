using EventManager.Dominio.Entities;

namespace EventManager.Dominio.Services;

public interface IJwtService
{
    string GenerateToken(DJ dj);
}