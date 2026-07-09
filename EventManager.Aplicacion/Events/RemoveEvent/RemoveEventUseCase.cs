using EventManager.Dominio.Abstractions.Repositories;

namespace EventManager.Aplicacion.RemoveEvent;

public class RemoveEventUseCase(IDJRepository DjRepository)
{
    public void Execute(RemoveEventRequest request)
    {
        var dj = DjRepository.Get();
        if(dj == null) {throw new Exception("el dj no existe");}

        dj.RemoveEvent(request.id);
        DjRepository.SaveChanges();

    }
}