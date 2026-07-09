using EventManager.Dominio.Abstractions.Repositories;
using EventManager.Dominio.ValueObjects;

namespace EventManager.Aplicacion.Contacts.RemoveContacts;

public class RemoveContactUseCase(IDJRepository repository)
{
    public void Execute(RemoveContactRequest request)
    {
        var dj = repository.Get() ?? throw new Exception("El dj no existe");
        var ev = dj.EventList.Find(e => e.Id == request.id) ?? throw new Exception("El evento no existe");
        var number = new Number(request.number);
        ev.RemoveContact(number);

        repository.SaveChanges();
    }
}