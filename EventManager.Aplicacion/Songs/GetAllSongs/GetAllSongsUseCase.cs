using EventManager.Aplicacion.GetEvent;
using EventManager.Dominio.Abstractions.Repositories;
using EventManager.Dominio.Comun;

namespace EventManager.Aplicacion.Songs.GetAllSongs;

public class GetAllSongsUseCase (IDJRepository dJRepository)
{
    public GetAllSongsResponse Execute(GetAllSongsRequest request)
    {
        var dj = dJRepository.Get() ?? throw new EntityNotFoundException("El Dj no existe");
        var ev = dj.EventList.Find(e => e.Id == request.eventId) ?? 
                 throw new EntityNotFoundException("El evento no exisxte");
        var listSongs = new List<SongDto>();
        foreach(var s in ev.Songs)
        {
            var songDto = new SongDto(s.Id, s.Title, s.Link!);
            listSongs.Add(songDto);
        }
        return new GetAllSongsResponse(listSongs);
    }
}