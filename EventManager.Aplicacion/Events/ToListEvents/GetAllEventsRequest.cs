namespace EventManager.Aplicacion.Events.ToListEvents;

public record GetAllEventsRequest(DateTime? from, DateTime? to);