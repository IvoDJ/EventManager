using EventManager.Aplicacion.Events;

namespace EventManager.Aplicacion.Dj;

public record DjDto(String name, IEnumerable<EventDto> events);