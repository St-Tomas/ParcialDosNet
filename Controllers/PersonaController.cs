using ApiEfCore.Models;
using ApiEfCore.Services;
using Microsoft.AspNetCore.Mvc;
namespace ApiEfCore.Controllers;

[ApiController]
[Route("api/[controller]")] //para la consulta Tomas acordate de usar /api/persona antes de pedirle con un promp boludo a la ia KJAS Despues el codigo en si es bastante estandar y lo mismo de las demas apis
public class PersonaController : ControllerBase
{
    private readonly IPersonaService _personaService;
    public PersonaController(IPersonaService personaService)
    {
        _personaService = personaService;
    }
    [HttpGet]
    public async Task<ActionResult<List<Persona>>> GetAll()
    {
        return Ok(await _personaService.GetAllAsync());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Persona?>> GetById(int id)
    {
        var persona = await _personaService.GetByIdAsync(id);
        if (persona is null)
        {
            return NotFound("Persona no encontrada.");
        }
        return Ok(persona);
    }
    [HttpPost]
    public async Task<ActionResult<Persona>> Create(Persona persona)
    {
        var created = await _personaService.CreateAsync(persona);
        return CreatedAtAction(nameof(GetById), new { id = created.PersonaId }, created);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Persona persona)
    {
        var updated = await _personaService.UpdateAsync(id, persona);
        if (!updated)
        {
            return NotFound();
        }
        return Ok("Persona actualizada correctamente.");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _personaService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}