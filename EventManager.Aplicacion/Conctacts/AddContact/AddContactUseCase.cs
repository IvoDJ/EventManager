using EventManager.Dominio.Abstractions.Repositories;
using EventManager.Dominio.Entities;
using EventManager.Dominio.ValueObjects;

namespace EventManager.Aplicacion.Contacts.AddContact;

public class AddContactUseCase(IDJRepository dJRepository)
{
    public void Execute(AddContactRequest request)
    {
        var dj = dJRepository.Get() ?? throw new Exception("El dj no existe");
        var ev = dj.EventList.Find(e => e.Id == request.id) ?? throw new Exception("El evento no existe");

        var name = new Name(request.name);
        var number = new Number(request.number);
        ev.AddContact(new Contact(name, number));

        dJRepository.SaveChanges();
    }
}