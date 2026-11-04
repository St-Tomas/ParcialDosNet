using ApiEfCore.Models;
using ApiEfCore.Services;
using Microsoft.AspNetCore.Mvc;
namespace ApiEfCore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaService _categoriaService;

    public CategoriaController(ICategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Categoria>>> GetAll()
    {
        return Ok(await _categoriaService.GetAllAsync());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Categoria>> GetById(int id)
    {
        var categoria = await _categoriaService.GetByIdAsync(id);
        if (categoria is null)
        {
            return NotFound();
        }
        return Ok(categoria);
    }
    [HttpPost]
    public async Task<ActionResult<Categoria>> Create(Categoria categoria)
    {
        var created = await _categoriaService.CreateAsync(categoria);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Categoria categoria)
    {
        var updated = await _categoriaService.UpdateAsync(id, categoria);
        if (!updated)
        {
            return NotFound();
        }
        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _categoriaService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return Ok();
    }
}