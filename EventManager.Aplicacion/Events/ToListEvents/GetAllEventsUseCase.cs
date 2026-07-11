using EventManager.Aplicacion.Events;
using EventManager.Dominio.Abstractions.Repositories;
using EventManager.Dominio.Events;
using EventManager.Aplicacion.Contacts;
using EventManager.Dominio.Comun;

namespace EventManager.Aplicacion.Events.ToListEvents;

public class GetAllEventsUseCase(IDJRepository repository)
{
    public ToListEventsResponse Execute(GetAllEventsRequest request)
    {
        var Dj = repository.Get();
        if(Dj == null) {throw new Exception("El DJ no existe");}

        var events_dto = new List<EventDto>();
        var djEvents = new List<Event>();

        if((request.from is null) && (request.to != null))
        {
         djEvents = Dj.EventList.Where(e => e.Date <= request.to).ToList();   
        }
        else if ((request.from.HasValue) && (request.to is null))
        {
            djEvents = Dj.EventList.Where(e => e.Date >= request.from).ToList();
        }
        else if((request.from.HasValue) && (request.to.HasValue))
        {
            djEvents = Dj.EventList.Where(e => e.Date >= request.from && e.Date <= request.to).ToList();
        }
        else
        {
            djEvents = Dj.EventList;
        }

        foreach (var e in djEvents)
        {   
            var contact_dtos = new List<ContactDto>();
            foreach (var c in e.Contacts)
            {
                var contact_dto = new ContactDto(c.Name.Value, c.Number.Value);
                contact_dtos.Add(contact_dto);
            }
            var event_dto = new EventDto(e.Id, e.Type.ToString(), e.Date, e.Location.Value, contact_dtos, e.State.ToString(), e.Duration);
            events_dto.Add(event_dto);   
        }
        return new ToListEventsResponse(events_dto);
    }
}
