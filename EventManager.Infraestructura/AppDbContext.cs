using EventManager.Dominio.Entities;
using EventManager.Dominio.Events;
using EventManager.Dominio.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Infraestructura;

public class AppDbContext : DbContext
{
    public DbSet<DJ> Djs {get; set;}

   public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { } //Establece las opciones necesarias parag configurar el motor de base de datos

   protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Le indicamos a EF Core que Email es un "Tipo Complejo" (Value Object)
        modelBuilder.Entity<DJ>().OwnsOne(dj => dj.Name);
        modelBuilder.Entity<DJ>().OwnsOne(dj => dj.User);
        modelBuilder.Entity<DJ>().OwnsMany(dj => dj.EventList, ev =>
        {
            ev.OwnsOne(e => e.Location);
            ev.OwnsMany(e => e.Contacts, c =>
            {
                c.OwnsOne(cont => cont.Name);
                c.OwnsOne(cont => cont.Number);
            });
            ev.OwnsMany(e => e.Songs);
        });
    }
}