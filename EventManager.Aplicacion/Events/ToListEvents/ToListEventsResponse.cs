namespace EventManager.Aplicacion.Events.ToListEvents;
public record ToListEventsResponse(IEnumerable<EventDto> events);