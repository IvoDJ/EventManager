namespace EventManager.Aplicacion;
using Microsoft.Extensions.DependencyInjection;
using EventManager.Aplicacion.Dj.RegisterDj;
using EventManager.Aplicacion.Events;
using EventManager.Aplicacion.GetEvent;
using EventManager.Aplicacion.RemoveEvent;
using EventManager.Aplicacion.Events.ToListEvents;
using EventManager.Aplicacion.Contacts.AddContact;
using EventManager.Aplicacion.Contacts.RemoveContacts;
using EventManager.Aplicacion.Songs.AddSong;
using EventManager.Aplicacion.Songs.RemoveSong;
using EventManager.Aplicacion.Login;

public static class ApplicationExtensions {

  public static IServiceCollection AddApplication(this IServiceCollection services)
  {
    services.AddScoped<GetEventByIdUseCase>();
    services.AddScoped<GetAllEventsUseCase>();
    services.AddScoped<RemoveEventUseCase>();
    services.AddScoped<RegisterDjUseCase>();
    services.AddScoped<AddEventUseCase>();
    services.AddScoped<AddContactUseCase>();
    services.AddScoped<RemoveContactUseCase>();
    services.AddScoped<AddSongUseCase>();
    services.AddScoped<RemoveSongUseCase>();
    services.AddScoped<AddSongUseCase>();
    services.AddScoped<LoginUseCase>();
    return services;
  }
    
}