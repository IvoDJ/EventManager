namespace EventManager.Infraestructura.Repositories;
using EventManager.Dominio.Abstractions.Repositories;
using EventManager.Dominio.Entities;
using Microsoft.EntityFrameworkCore;


public class DJRepository : IDJRepository
{
    private readonly AppDbContext _context;

    public DJRepository(AppDbContext context) //constructor, recibe por parametro una BD
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Add(DJ dj)
    {
        _context.Add(dj);
        _context.SaveChanges();
    }
    public DJ? Get()
    {
      return _context.Djs
          .Include(dj => dj.EventList)
              .ThenInclude(e => e.Contacts)
          .Include(dj => dj.EventList)
              .ThenInclude(e => e.Songs)
          .FirstOrDefault();
    }
    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}