namespace EventManager.Aplicacion.Songs.AddSong;

public record AddSongRequest(Guid idEvent, String title, String url);