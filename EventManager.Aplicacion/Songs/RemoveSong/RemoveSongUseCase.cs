using EventManager.Dominio.Abstractions.Repositories;

namespace EventManager.Aplicacion.Songs.RemoveSong;

public class RemoveSongUseCase(IDJRepository dJRepository)
{
    public void Execute(RemoveSongRequest request)
    {
        var dj = dJRepository.Get();
        if(dj is null) {throw new Exception("El dj no existe");}

        var ev = dj.EventList.Find(ev => ev.Id == request.idEvent);
        if(ev is null) {throw new Exception("El evento no existe");}

        ev.RemoveSong(request.idSong);
        dJRepository.SaveChanges();
    }
}