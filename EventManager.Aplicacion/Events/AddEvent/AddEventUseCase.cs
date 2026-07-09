using System.Net.Cache;
using System.Timers;
using EventManager.Aplicacion.Events.AddEvent;
using EventManager.Dominio.Abstractions.Repositories;
using EventManager.Dominio.Entities;
using EventManager.Dominio.Events;
using EventManager.Dominio.ValueObjects;

namespace EventManager.Aplicacion.Events;

public class AddEventUseCase(IDJRepository DjRepository)
{
    public void Execute(AddEventRequest request)
    {
        var dj = DjRepository.Get();
        if(dj == null)
        {
            throw new Exception("El Dj no existe");
        }           
        var location = new Location(request.loc);
        var ev = new Event(request.type, request.date, location, request.state, request.duration);
        dj.AddEvent(ev);
        DjRepository.SaveChanges();
    }
}