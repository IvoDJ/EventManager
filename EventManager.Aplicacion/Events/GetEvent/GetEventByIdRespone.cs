using EventManager.Aplicacion.Events;
using EventManager.Dominio.Events;

namespace EventManager.Aplicacion.GetEvent;

public record GetEventByIdResponse(EventDto e);