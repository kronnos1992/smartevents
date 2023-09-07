using gesteventos.Data;
using gesteventos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gesteventos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly DataContext context;

    public EventsController(DataContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var events = await this.context.Events.ToListAsync();
        if (events.Count > 0)
        {
            return Ok(events);

        }
        return NotFound("Nenhum registro encontrado");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var eventF = await context.Events.FindAsync(id);
        if (eventF != null)
        {
            return Ok(eventF);

        }
        return NotFound("Nenhum registro encontrado");
    }

    [HttpPost]
    public async Task<IActionResult> Add(Event eventd)
    {
        await context.AddAsync(eventd);
        if (ModelState.IsValid)
        {
            await context.SaveChangesAsync();
            return Ok();
        }
        return BadRequest("Erro de banco de dados.");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody] Event events, int id)
    {
        var eventf = await context.Events.FindAsync(id);
        if (eventf == null)
        {
            context.UpdateRange(eventf);
            if (ModelState.IsValid)
            {
                await context.SaveChangesAsync();
                return Created("", eventf);
            }
            return BadRequest("Erro de banco de dados");
        }
        return NotFound("Nenhum registro encontrado");
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(int id)
    {
        var eventf = await context.Events.FindAsync(id);
        if (eventf != null)
        {
            context.UpdateRange(eventf);
            if (ModelState.IsValid)
            {
                await context.SaveChangesAsync();
                return Created("", eventf);
            }
            return BadRequest("Erro de banco de dados");
        }
        return NotFound("Nenhum registro encontrado");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var eventf = await context.Events.FindAsync(id);
        if (eventf != null)
        {
            context.UpdateRange(eventf);
            if (ModelState.IsValid)
            {
                await context.SaveChangesAsync();
                return StatusCode(203, "registro eliminado.");
            }
            return BadRequest("Erro de banco de dados");
        }
        return NotFound("Nenhum registro encontrado");
    }
}
