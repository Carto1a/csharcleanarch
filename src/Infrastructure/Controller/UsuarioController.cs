using CSharpCleanArch.Application.DataTransport.Input;
using CSharpCleanArch.Application.Mappers;
using CSharpCleanArch.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace CSharpCleanArch.Infrastructure.Controller;
[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUsuario(
        [FromServices] CreateUsuarioUseCase useCase,
        [FromBody] UsuarioInputDto request)
    {
        var result = await useCase.Handler(request.toDomain());
        return Ok(result);
        /* return CreatedAtRoute("GetUsuario", new { id = result.Id }); */
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsuarios(
        [FromServices] GetAllUsuariosUseCase useCase)
    {
        var result = await useCase.Handler();
        return Ok(result);
    }
}