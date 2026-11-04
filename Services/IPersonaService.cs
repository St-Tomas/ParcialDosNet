using ApiEfCore.Models;
namespace ApiEfCore.Services;

public interface IPersonaService
{
    Task<List<Persona>> GetAllAsync();
    Task<Persona?> GetByIdAsync(int id);
    Task<Persona> CreateAsync(Persona persona);
    Task<bool> UpdateAsync(int id, Persona persona);
    Task<bool> DeleteAsync(int id);
}