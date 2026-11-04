using ApiEfCore.Models;
using ApiEfCore.Services;
using Microsoft.AspNetCore.Mvc;
namespace ApiEfCore.Controllers;

[ApiController]
[Route("api/[controller]")] 
public class NotaController : ControllerBase
{
 
    private readonly INotaService _notaService;
    public NotaController(INotaService notaService)
    {
        _notaService = notaService;
    }
    [HttpGet]
    public async Task<ActionResult<List<Nota>>> GetAll()
    {
        return Ok(await _notaService.GetAllAsync());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Nota?>> GetById(int id)
    {
        var nota = await _notaService.GetByIdAsync(id);
        if (nota is null)
        {
            return NotFound();
        }
        return Ok(nota);
    }
    [HttpPost]
    public async Task<ActionResult<Nota>> Create(Nota nota)
    {
        var created = await _notaService.CreateAsync(nota);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Nota nota)
    {
        var updated = await _notaService.UpdateAsync(id, nota);
        if (!updated)
        {
            return NotFound("Nota no encontrada.");
        }
        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _notaService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound("Nota no encontrada.");
        }
        return NoContent();
    }
}