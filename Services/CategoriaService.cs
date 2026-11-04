using ApiEfCore.Context;
using ApiEfCore.Models;
using Microsoft.EntityFrameworkCore;
namespace ApiEfCore.Services;

public class CategoriaService : ICategoriaService
{
    private readonly AppDbContext _dbContext;

    public CategoriaService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Categoria>> GetAllAsync()
    {
        return await _dbContext.Categorias.ToListAsync();
    }

    public async Task<Categoria?> GetByIdAsync(int id)
    {
        return await _dbContext.Categorias.FindAsync(id);
    }

    public async Task<Categoria> CreateAsync(Categoria categoria)
    {
        _dbContext.Categorias.Add(categoria);
        await _dbContext.SaveChangesAsync();
        return categoria;
    }

    public async Task<bool> UpdateAsync(int id, Categoria categoria)
    {
        var existing = await _dbContext.Categorias.FindAsync(id);
        if (existing == null)
        {
            return false;
        }

        existing.Nombre = categoria.Nombre;

        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var categoria = await _dbContext.Categorias.FindAsync(id);
        if (categoria == null)
        {
            return false;
        }
        _dbContext.Categorias.Remove(categoria);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}