using EventManager.Dominio.Abstractions.Repositories;
using EventManager.Dominio.Comun;
using EventManager.Dominio.Services;

namespace EventManager.Aplicacion.Login;

public class LoginUseCase(IDJRepository djRepo, IJwtService jwtService)
{
    public LoginResponse Execute(LoginRequest request)
    {
        var dj = djRepo.Get() ?? throw new DomainException("El dj no existe");
        if((request.username != dj.User.Username) || (request.password != dj.User.Password))
        {
            throw new Exception ("Credenciales Inválidas");
        }
        return new LoginResponse(jwtService.GenerateToken(dj));    
    }
}