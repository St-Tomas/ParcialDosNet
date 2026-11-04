namespace ApiEfCore.Services;
using ApiEfCore.Context;
using ApiEfCore.Models;
using Microsoft.EntityFrameworkCore;
public class NotaService : INotaService
{
    private readonly AppDbContext _dbContext;
    public NotaService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<Nota>> GetAllAsync()
    {
        return await _dbContext.Notas.ToListAsync();
    }
    public async Task<Nota?> GetByIdAsync(int id)
    {
        return await _dbContext.Notas.FindAsync(id); 
    }
    public async Task<Nota> CreateAsync(Nota nota)
    {
        _dbContext.Notas.Add(nota);
        await _dbContext.SaveChangesAsync();
        return nota;
    }
    public async Task<bool> UpdateAsync(int id, Nota nota)
    {
        var existing = await _dbContext.Notas.FindAsync(id);
        if (existing is null)
        {
            return false; 
        }
        var persona = await _dbContext.Personas.FindAsync(nota.PersonaId);
        if (persona is null)
        {
            return false;
        }
        if (nota.CategoriaId != null)
        {
            var categoria = await _dbContext.Categorias.FindAsync(nota.CategoriaId);
            if (categoria is null)
            {
                return false;
            }
        }
        existing.Titulo = nota.Titulo;
        existing.Descripcion = nota.Descripcion;
        existing.Completa = nota.Completa;
        existing.CategoriaId = nota.CategoriaId;
        existing.PersonaId = nota.PersonaId;
        await _dbContext.SaveChangesAsync();
        return true;
    }
    public async Task<bool> DeleteAsync(int id)
    {
         var existing = await _dbContext.Notas.FindAsync(id);
        if (existing is null)
        {
            return false; 
        }
        _dbContext.Notas.Remove(existing);
        await _dbContext.SaveChangesAsync(); 
        return true;
    }
}