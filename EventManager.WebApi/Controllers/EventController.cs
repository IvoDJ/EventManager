using EventManager.Aplicacion.Events;
using EventManager.Aplicacion.Events.AddEvent;
using EventManager.Aplicacion.Events.ToListEvents;
using EventManager.Aplicacion.GetEvent;
using EventManager.Aplicacion.RemoveEvent;
using EventManager.Aplicacion.Songs.AddSong;
using EventManager.Aplicacion.Songs.RemoveSong;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace EventManager.WebApi.Controllers;

[ApiController]
[Route("dj/event")]
[Authorize]
public class EventController : ControllerBase
{
    private readonly AddEventUseCase _addEvent;
    private readonly GetAllEventsUseCase _allEvents;
    private readonly GetEventByIdUseCase _byIdEvent;
    private readonly RemoveEventUseCase _removeEvent;
    private readonly AddSongUseCase _addSong;
    private readonly RemoveSongUseCase _removeSong;

    public EventController(AddEventUseCase addEvent, GetAllEventsUseCase allEvents, 
                           GetEventByIdUseCase byIdEvent, RemoveEventUseCase removeEvent,
                           AddSongUseCase addSong, RemoveSongUseCase removeSong)
    {
        _addEvent = addEvent;
        _allEvents = allEvents;
        _byIdEvent = byIdEvent;
        _removeEvent = removeEvent;
        _addSong = addSong;
        _removeSong = removeSong;

    }

    [HttpPost]
    public IActionResult AddEvent([FromBody] AddEventRequest request)
    {

            _addEvent.Execute(request);
            return Ok("Evento agregado correctamente");
    }

    [HttpGet]
    public IActionResult GetAllEvents([FromQuery] DateTime? from, [FromQuery] DateTime? to)
    {
           var fullrequest = new GetAllEventsRequest(from, to);
           var lista = _allEvents.Execute(fullrequest);
            return Ok(lista);
    }

    [HttpGet("{id}")]
    public IActionResult GetEventById([FromRoute] Guid id)
    {
        var request = new GetEventByIdRequest(id);
            var ev = _byIdEvent.Execute(request);
            return Ok(ev);
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveEvent([FromRoute] Guid id)
    {
        var request = new RemoveEventRequest(id);
            _removeEvent.Execute(request);
            return Ok("Evento removido con exito");

    }

}
