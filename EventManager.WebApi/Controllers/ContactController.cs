using EventManager.Aplicacion.Contacts.AddContact;
using EventManager.Aplicacion.Contacts.RemoveContacts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace EventManager.WebApi.Controllers;

[ApiController]
[Route("dj/event/{eventId}/contact")]
[Authorize]
public class ContactController : ControllerBase
{
    private readonly AddContactUseCase _addContact;
    private readonly RemoveContactUseCase _removeContact;

    public ContactController(RemoveContactUseCase remove, AddContactUseCase add)
    {
        _addContact = add;
        _removeContact = remove;
    }
    public record AddContactBody(string name, string number);

    [HttpPost]
    public IActionResult AddContact([FromRoute] Guid eventId, [FromBody] AddContactBody body)
    {
        var fullRequest = new AddContactRequest(body.name, body.number, eventId);
        _addContact.Execute(fullRequest);
        return Ok("Contacto agregado");
    }

    [HttpDelete("{number}")]
    public IActionResult RemoveContact([FromRoute] Guid eventId, [FromRoute] String number )
    {
        var fullRequest = new RemoveContactRequest(eventId, number);
        _removeContact.Execute(fullRequest);
        return Ok("Contacto eliminado");


    }
}