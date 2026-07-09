using EventManager.Dominio.Abstractions;
using EventManager.Dominio.Comun;

namespace EventManager.Dominio.Entities.Song;

public class Song : Entity
{
    public String Title {get; private set;}
    public String? Link {get; private set;}

    public Song(String title, String link)
    {
        if(String.IsNullOrEmpty(title)) {throw new DomainException("El titulo es obligatorio");}
        this.Title = title;
        Link = String.IsNullOrEmpty(link) ? "No aplica" : link;
    }

    protected Song(){}
    
}