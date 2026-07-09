using EventManager.Dominio.Abstractions;
using EventManager.Dominio.Abstractions.Repositories;

namespace EventManager.Aplicacion.Songs.AddSong;

public class AddSongUseCase (IDJRepository dJRepository)
{
    public void Execute(AddSongRequest request)
    {
        var dj = dJRepository.Get();
        if(dj is null){throw new Exception("El Dj no existe");}

        var ev = dj.EventList.Find(ev => ev.Id == request.idEvent);
        if(ev is null){throw new Exception("El evento no existe");}

        ev.AddSong(new(request.title, request.url));
        dJRepository.SaveChanges();
    }
}