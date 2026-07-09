using EventManager.Dominio.Entities.Song;

namespace EventManager.Aplicacion.Songs.GetAllSongs;

public record GetAllSongsResponse(IEnumerable<SongDto> songs);