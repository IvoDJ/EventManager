using EventManager.Dominio.ValueObjects;

namespace EventManager.Aplicacion.Login;

public record LoginRequest(String username, String password);