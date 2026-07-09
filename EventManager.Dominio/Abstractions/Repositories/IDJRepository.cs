using EventManager.Dominio.Entities;
namespace EventManager.Dominio.Abstractions.Repositories;

public interface IDJRepository
{
    void Add(DJ dj);
    DJ? Get();
    void SaveChanges();
}