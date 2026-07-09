using EventManager.Aplicacion.Songs.AddSong;
using EventManager.Aplicacion.Songs.GetAllSongs;
using EventManager.Aplicacion.Songs.RemoveSong;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace EventManager.WebApi.Controllers;
[ApiController]
[Authorize]
[Route("dj/event/{eventId}/song")]

public class SongController : ControllerBase
{
    private readonly AddSongUseCase _addSong;
    private readonly RemoveSongUseCase _removeSong;
    private readonly GetAllSongsUseCase _getAll;

    public SongController(AddSongUseCase add, RemoveSongUseCase remove, GetAllSongsUseCase get)
    {
        _addSong = add;
        _removeSong = remove;
        _getAll = get;
    }

    public record AddSongBody(string title, string url);
    [HttpPost]
    public IActionResult AddSong([FromRoute] Guid eventId, [FromBody] AddSongBody body)
    {
        var fullRequest = new AddSongRequest(eventId, body.title, body.url);
        _addSong.Execute(fullRequest);
        return Ok("Cancion agregada exitosamente");
    }

    [HttpDelete("{idSong}")]
    public IActionResult RemoveSong([FromRoute] Guid eventId, [FromRoute] Guid idSong)
    {
        var request = new RemoveSongRequest(eventId, idSong);
        _removeSong.Execute(request);
        return Ok("Cancion eliminada exitosamente!");
        
    }

    [HttpGet]
    public IActionResult GetAllSongs([FromRoute] Guid eventId)
    {
        var req = new GetAllSongsRequest(eventId);
        var lista = _getAll.Execute(req);
        return Ok(lista);
    }


}