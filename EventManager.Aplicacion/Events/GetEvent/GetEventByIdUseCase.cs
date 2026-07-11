using EventManager.Aplicacion.Contacts;
using EventManager.Aplicacion.Events;
using EventManager.Dominio.Abstractions.Repositories;
using EventManager.Dominio.Events;

namespace EventManager.Aplicacion.GetEvent;
public class GetEventByIdUseCase(IDJRepository Repository)
{
    public GetEventByIdResponse Execute(GetEventByIdRequest request)
    {
        var dj = Repository.Get();
        if(dj == null) {throw new Exception("El DJ no existe");}

        var djEvents = dj.EventList;
        var evfound = djEvents.Find(e => e.Id == request.id);

        if(evfound == null) {throw new Exception("El Evento no existe");}

        var contacts = new List<ContactDto>();
        foreach (var c in evfound.Contacts)
        {
            var contactDto = new ContactDto(c.Name.Value, c.Number.Value);
            contacts.Add(contactDto);
        }
        var eventDto = new EventDto (evfound.Id, evfound.Type.ToString(), evfound.Date, evfound.Location.Value, contacts, evfound.State.ToString(), evfound.Duration);
        return new GetEventByIdResponse(eventDto);
    }
    
}