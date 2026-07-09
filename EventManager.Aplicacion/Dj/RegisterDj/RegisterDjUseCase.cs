using EventManager.Aplicacion.Events;
using EventManager.Dominio.ValueObjects;
using EventManager.Dominio.Abstractions.Repositories;
using EventManager.Dominio.Entities;
using EventManager.Dominio.Comun;

namespace EventManager.Aplicacion.Dj.RegisterDj;

public class RegisterDjUseCase(IDJRepository DjRepository)
{
    public void Execute(RegisterDjRequest request)
    {
        if(DjRepository.Get() != null)
        {
            throw new DomainException("Ya existe un DJ registrado");
        }
        var name = new Name(request.name);
        var user = new User(request.username, request.password);
        DjRepository.Add(new DJ(name, user));   
    }
}