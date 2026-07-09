namespace EventManager.Dominio.Entities;
using ValueObjects;
using EventManager.Dominio.Abstractions;
using EventManager.Dominio.Events;
using EventManager.Dominio.Comun;

public class DJ : Entity
{
    public User User {get; private set;}
    public Name Name {get; private set;} = null!;
    public List<Event> EventList {get; private set;} = new ();

    public DJ(Name name, User user) {this.Name = name; this.User = user;}
    protected DJ(){}

    public void AddEvent(Event e) => EventList.Add(e);
    public void RemoveEvent(Guid id)
    {
        var e = EventList.Find(ev => ev.Id == id);
        if(e is null)
        {
            throw new DomainException("El evento no existe");
        }
        EventList.Remove(e);
    }
}