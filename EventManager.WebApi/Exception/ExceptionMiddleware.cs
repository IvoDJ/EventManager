using EventManager.Dominio.Comun;
using Microsoft.AspNetCore.Http.HttpResults;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _iLogger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> iLog)
    {
        _next = next;
        _iLogger = iLog;

    }

    public async Task Invoke(HttpContext context) //DEFINIR EXCEPCIIONES EN CAPA APLICACION
    {
        _iLogger.LogInformation($"Solicitud realizada {context.Request.Path}");
        try
        {
            await _next(context);
        }
        catch (DomainException ex)
        {
          context.Response.StatusCode = 400;
          await context.Response.WriteAsJsonAsync(new {message = ex.Message});
        }
        catch (Exception)
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync("Ocurrio un error inesperado");
        }
        // si tira excepción, la atrapás acá
    }
}