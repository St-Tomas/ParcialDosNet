using ApiEfCore.Context;
using ApiEfCore.Models;
using Microsoft.EntityFrameworkCore;
namespace ApiEfCore.Services;

public class PersonaService : IPersonaService
{
    private readonly AppDbContext _dbContext;
    public PersonaService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<Persona>> GetAllAsync()
    {
        return await _dbContext.Personas.ToListAsync(); //esto es corte como un SELECT FROM Personas pa que entienda
    }
    public async Task<Persona?> GetByIdAsync(int id)
    {
        return await _dbContext.Personas.FindAsync(id); //este me busca por la clave PRIMAria, si no exisxte tira un null
    }
    public async Task<Persona> CreateAsync(Persona persona)
    {
        _dbContext.Personas.Add(persona);
        await _dbContext.SaveChangesAsync(); //hace el insert en la db
        return persona;
    }
    public async Task<bool> UpdateAsync(int id, Persona persona)
    {
        var existing = await _dbContext.Personas.FindAsync(id);
        if (existing is null)
        {
            return false; //devuelvo false asi el controller despues tira 404
        }
        existing.Nombre = persona.Nombre;
        await _dbContext.SaveChangesAsync(); //hace el update en la db
        return true;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _dbContext.Personas.FindAsync(id);
        if (existing is null)
        {
            return false; //lo mismo que arriba kjj
        }
        _dbContext.Personas.Remove(existing);
        await _dbContext.SaveChangesAsync(); //tira el delete en la db
        return true;
    }
}