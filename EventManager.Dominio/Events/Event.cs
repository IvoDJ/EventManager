namespace EventManager.Dominio.Events;
using EventManager.Dominio.Abstractions;
using EventManager.Dominio.Comun;
using EventManager.Dominio.Entities;
using EventManager.Dominio.Entities.Song;
using EventManager.Dominio.ValueObjects;
public class Event : Entity
{
    public TypeEvent Type {get;private set;} 
    public DateTime Date {get; private set;}
    public Location Location {get; private set;} = null!;
    public List<Contact> Contacts {get; private set;} = new();
    public List<Song> Songs {get; private set;} = new();
    public EventState State {get; private set;}
    public int Duration {get; private set;}

    public Event(TypeEvent type, DateTime date, Location location, EventState state, int duration)
    {
        if(!Enum.IsDefined(typeof(EventState), state))
        {
            throw new DomainException("El estado ingresado es inválido");
        }
        if(!Enum.IsDefined(typeof(TypeEvent), type))
        {
            throw new DomainException("El tipo ingresado es inválido");
        }
        if(duration < 6 || duration > 8)
        {
            throw new DomainException("La duración del evento debe ser ntre 6 y 8 horas");
        }
        Type = type;
        Date = date;
        Location = location;
        State = state;
        Duration = duration;
    }
    protected Event(){}
    public void AddContact(Contact con)
    {
        Contacts.Add(con);
    }

    public void RemoveContact(Number number)
    {
        var n = Contacts.Find(c => c.Number == number);
        if(n is null)
        {
            throw new DomainException("El contacto no existe");
        }
        Contacts.Remove(n);
    }

    public void Reschedule(DateTime date)
    {
        if(date < this.Date)
        {
            throw new DomainException("La fecha nueva no puede ser anterior a la actual");
        }
        this.Date = date;
    }

    public void UpdateLocation(Location loc) => this.Location = loc;
    public void UpdateState(EventState es)
    {
        if(State == es)
        {
            throw new DomainException("El estado nuevo debe ser diferente al actual");
        }
        if(!Enum.IsDefined(typeof(EventState), es))
        {
            throw new DomainException("El estado ingresado es inválido");
        }
        State = es;
    }

    public void AddSong(Song song) => Songs.Add(song);
    public void RemoveSong(Guid idSong)
    {
        var s = Songs.Find(s => s.Id == idSong);
        if(s is null) {throw new DomainException("La cancion no está en la lista");}
        Songs.Remove(s);
    }
}
