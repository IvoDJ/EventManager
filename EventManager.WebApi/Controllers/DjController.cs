using EventManager.Aplicacion.Dj.RegisterDj;
using EventManager.Aplicacion.Login;
using EventManager.Dominio.Abstractions.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.WebApi.Controllers;

[ApiController]
[Route("dj")]

public class DjController : ControllerBase
{
    private readonly RegisterDjUseCase _registerDj;
    private readonly LoginUseCase _loginDj;

    public DjController(RegisterDjUseCase registerDj, LoginUseCase logDj) {
         _registerDj = registerDj; 
         _loginDj = logDj;
    }

    [HttpPost]
    public IActionResult RegisterDj([FromBody] RegisterDjRequest request)
    {
        _registerDj.Execute(request);
        return Ok("DJ registrado correctamente"); 
    }

    [HttpPost("login")]
    public IActionResult LoginDj([FromBody] LoginRequest request)
    {
        var log = _loginDj.Execute(request);
        return Ok(log);    
    }
    
    
}