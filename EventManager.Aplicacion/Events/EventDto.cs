namespace EventManager.Aplicacion.Events;

using EventManager.Dominio.Abstractions.Repositories;
using EventManager.Dominio.Entities;
using EventManager.Dominio.Events;
using EventManager.Dominio.ValueObjects;
using EventManager.Aplicacion.Contacts;

public record EventDto(Guid id, String type, DateTime date, String loc, 
                        IEnumerable<ContactDto> contacts, String es, int duration);