using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gesteventos.Application.Services.Implementations;
using gesteventos.Domain.Models;
using gesteventos.Application.Services.Interfaces;

namespace gesteventos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventosController : ControllerBase
{
    private readonly IEventoService service;

    public EventosController(IEventoService service)
    {
        this.service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var eventos = await this.service.GetAllEventosAsync();
            if (eventos.Length > 0)
            {
                return Ok(eventos);

            }
            return NotFound("Nenhum registro encontrado");
        }
        catch (Exception ex)
        {
            //StatusCodes.Status500InternalServerError
            return StatusCode(500, $"Erro ao recuperar dados do banco {ex.Message}");
        }
    }
    [HttpGet("{tema}/tema")]
    public async Task<IActionResult> Get(string tema)
    {
        try
        {
            var eventos = await this.service.GetEventosByTemaAsync(tema, true);
            if (eventos.Length > 0)
            {
                return Ok(eventos);

            }
            return NotFound("Nenhum registro encontrado");
        }
        catch (Exception ex)
        {
            //StatusCodes.Status500InternalServerError
            return StatusCode(500, $"Erro ao recuperar dados do banco {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var evento = await service.GetEventoByIdAsync(id);
            if (evento != null)
            {
                return Ok(evento);
            }
            return NotFound("Nenhum registro encontrado");
        }
        catch (Exception ex)
        {
            //StatusCodes.Status500InternalServerError
            return StatusCode(500, $"Erro ao recuperar dados do banco {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Insert(Evento evento)
    {
        try
        {
            var _evento = await service.InsertEvento(evento);
            if (ModelState.IsValid)
            {
                return Ok(_evento);
            }
            return BadRequest("Erro de banco de dados.");
        }
        catch (Exception ex)
        {
            //StatusCodes.Status500InternalServerError
            return StatusCode(500, $"Erro ao recuperar dados do banco {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromBody] Evento evento, int id)
    {
        try
        {
            await service.UpdateEvento(id, evento);
            if (ModelState.IsValid)
            {
                return CreatedAtRoute("", "Evento Atualizado");
            }
            return NotFound("Nenhum registro encontrado");
        }
        catch (Exception ex)
        {
            //StatusCodes.Status500InternalServerError
            return StatusCode(500, $"Erro ao recuperar dados do banco {ex.Message}");
        }
    }
    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch([FromBody] Evento evento, int id)
    {
        try
        {
            await service.UpdateEvento(id, evento);
            if (ModelState.IsValid)
            {
                return CreatedAtRoute("", "Evento atualizado");
            }
            return NotFound("Nenhum registro encontrado");
        }
        catch (Exception ex)
        {
            //StatusCodes.Status500InternalServerError
            return StatusCode(500, $"Erro ao recuperar dados do banco {ex.Message}");
        }

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await service.DeleteEvento(id);
            return StatusCode(203, "Evento eliminado.");
        }
        catch (Exception ex)
        {
            //StatusCodes.Status500InternalServerError
            return StatusCode(500, $"Erro ao deletar {ex}");
        }

    }
}
