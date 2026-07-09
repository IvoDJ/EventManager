using System.Data;
using EventManager.Dominio.Events;
using EventManager.Dominio.ValueObjects;

namespace EventManager.Aplicacion.Events.AddEvent;

public record AddEventRequest(TypeEvent type, DateTime date, String loc, EventState state, int duration);